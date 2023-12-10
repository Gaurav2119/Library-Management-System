import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;
  loginRes: string = '';

  get username(): FormControl {
    return this.loginForm.get('username') as FormControl;
  }
  get password(): FormControl {
    return this.loginForm.get('password') as FormControl;
  }

  getUsernameErrors() {
    if (this.username.hasError('required')) return '*Username is required!';
    return '';
  }

  getPasswordErrors() {
    if (this.password.hasError('required')) return '*Password is required!';
    return '';
  }

  login(){
    let loginInfo = {
      username : this.loginForm.get('username')?.value,
      password : this.loginForm.get('password')?.value
    }

    this.userservice.login(loginInfo).subscribe({
      next: (res: any) => {
        if (res === 'Invalid Credentials!') this.loginRes = res;
        else {
          this.loginRes = '';
          this.userservice.saveToken(res.toString());
          this.router.navigate(['dashboard']).then(() => {
            location.reload();
          })
        }
      }
    })
  }

  constructor(
    private fb: FormBuilder,
    private userservice: UserService,
    private router: Router
  ){
    this.loginForm = fb.group({
      username: fb.control('', Validators.required),
      password: fb.control('', Validators.required)
    })
  }

}
