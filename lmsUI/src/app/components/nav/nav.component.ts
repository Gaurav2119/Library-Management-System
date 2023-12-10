import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  token$ : any

  ngOnInit() {
    if (this.userservice.isLoggedIn()){
      let userId = this.userservice.getTokenUserInfo()?.id;

      this.userservice.token(userId).subscribe({
        next: (res) => {
          this.token$ = res;
        }
      })
    }
  }

  login(){
    this.router.navigate(['login']);
  }

  addbook(){
    this.router.navigate(['addbook']);
  }

  mybooks(){
    this.router.navigate(['mybooks']);
  }

  myorders(){
    this.router.navigate(['myorders']);
  }

  logOut(){
    this.userservice.deleteToken();
  }

  constructor(
    public userservice : UserService,
    private router: Router
  ){}
}
