import { Injectable } from '@angular/core';
import {HttpService} from './http.service'
import { RegistrationModel } from 'src/app/Models/Common/registration-model';
import { Observable } from 'rxjs';
import { LoginModel } from 'src/app/Models/Common/login-model';
import { PersonelDetails } from 'src/app/Models/Common/personel-details';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpService) { }

  public registration(data: RegistrationModel): Observable<any> {

    return this.http.post<any>("http://localhost:56186/api/Users/registration", data);
  }

  public login(data: LoginModel): Observable<any> {
    return this.http.post<any>("http://localhost:56186/api/users/login", data);
  }

  public UploadPersonalData(formData:FormData): Observable<any> {
    return this.http.postForm<any>("http://localhost:56186/api/users/personel-details/update", formData);
  }

}
