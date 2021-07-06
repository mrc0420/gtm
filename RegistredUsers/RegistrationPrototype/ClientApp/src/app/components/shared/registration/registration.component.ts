import { Component, OnInit } from '@angular/core';
import { RegistrationModel } from 'src/app/Models/Common/registration-model';
import { UserService } from 'src/app/Service/WebRequest/user.service';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  validationMessage: string;
  public registration: RegistrationModel;

  constructor(private userService:UserService, private router:Router) {
    this.validationMessage = '';
    this.registration = new RegistrationModel();
  }

  ngOnInit() {
  }

  public isValidateCredential(): boolean
  {
    if (this.registration.password != this.registration.confirmPassword) {
      this.validationMessage = "Password Should be Same";
      return false;
    }
    else
      return true;
  }


  public submit(): void {

    if (!this.isValidateCredential())
    { return }
    //alert(this.registration.email);
    this.userService.registration(this.registration).subscribe((response: HttpResponse<any>) => {
      if (response) {
        this.router.navigateByUrl('login');
        alert("Registration successful");
      }

      else {
        alert("Registration failed");
        (error: HttpErrorResponse) => {
          console.log(error);
        }
      }
});
    


  }



}
