import { Component } from '@angular/core';
import { Login } from '../../interfaces/login';
import { JwtAuth } from '../../interfaces/jwt-auth';
import { AuthenticationService } from '../../services/authentication.service';
import { Router } from '@angular/router';
import { faHome, faEyeSlash, faEye } from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginDto: Login = {
    username: '',
    password: ''
  };
  jwtDto: JwtAuth = {
    result: true,
    token: '',
    error: undefined
  };

  faHome = faHome;
  faEyeSlash = faEyeSlash;
  faEye = faEye;

  showPassword = false;

  constructor(private authService: AuthenticationService, private router:Router) { }

  login():void {
    const data = {
      username:this.loginDto.username,
      password:this.loginDto.password
    }
    this.authService.login(data).subscribe((jwtDto) => {
      localStorage.setItem('jwtToken', jwtDto.token);
      this.router.navigate(['/home']);
    });
  }
  togglePasswordVisibility(): void {
    this.showPassword = !this.showPassword;
  }
}
