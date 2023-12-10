import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = "https://localhost:7283/api/User/";

  saveToken(token: string){
    localStorage.setItem('access_token', token);
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('access_token');
  }

  deleteToken(){
    localStorage.removeItem('access_token');
    location.reload();
  }

  getTokenUserInfo(): User | null {
    if (!this.isLoggedIn()) return null;
    let token = this.jwt.decodeToken();
    let user: User = {
      id: token.id,
      name: token.name,
      username: token.username
    };
    return user;
  }

  login(loginInfo: any){
    let params = new HttpParams()
    .append("username", loginInfo.username)
    .append("password", loginInfo.password);

    return this.http.get(this.baseUrl + "Login", {
      params: params,
      responseType: 'text',
    });
  }

  token(id: any){
    return this.http.get(this.baseUrl + 'Token/' + id);
  }

  constructor(
    private http: HttpClient,
    private jwt: JwtHelperService
  ) { }
}
