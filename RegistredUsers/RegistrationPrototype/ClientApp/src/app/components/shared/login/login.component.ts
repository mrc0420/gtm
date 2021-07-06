import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { LoginModel } from 'src/app/Models/Common/login-model';
import { UserService } from 'src/app/Service/WebRequest/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public login: LoginModel;
  public validationMessage: string;

  constructor(private userService: UserService,
    private router: Router) {
    this.login = new LoginModel();
    this.validationMessage = '';
  }

  ngOnInit() {
  }
  public submit(): void {
    //alert(this.login.email.toString());
    this.userService.login(this.login).subscribe((
      response: HttpResponse<any>) => {
      if (response) {
        this.router.navigateByUrl('dashboard');
      }
      this.validationMessage = " Invalid email or password";
      (error: HttpErrorResponse) => {
        
        alert(error);

        console.log(error);
       
      }
    });
  }
}
