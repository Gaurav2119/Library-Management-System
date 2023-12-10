import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { UserService } from "../services/user.service";

@Injectable({
  providedIn: 'root',
})

export class authenticationGuard implements CanActivate {
  constructor(
    private userservice: UserService,
    private router: Router
  ) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if (this.userservice.isLoggedIn())
      return true;
    else{
      this.router.navigate(["/dashboard"])
      return false;
    }
  }
}