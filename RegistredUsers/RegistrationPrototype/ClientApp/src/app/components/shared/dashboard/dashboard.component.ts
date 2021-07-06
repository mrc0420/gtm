import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpResponse,HttpEventType } from '@angular/common/http';
import { PersonelDetails } from 'src/app/Models/Common/personel-details';
import { UserService } from 'src/app/Service/WebRequest/user.service';
import { FormsModule, FormGroup, FormBuilder } from '@angular/forms';



@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
 
    form: FormGroup;
   constructor(private userService:UserService, private fb:FormBuilder) {
    
    this.form = this.fb.group({
      affiliation: [''],
      address: [''],
      userId:[],
      profilePicture: [null]
    })

  }

  ngOnInit() {
  }

    //test
  uploadFile(event) {
    const file = (event.target as HTMLInputElement).files[0];
    this.form.patchValue({
      profilePicture: file
    });
    this.form.get('profilePicture').updateValueAndValidity()
  }

  //test
  submitForm() {
    var formData: any = new FormData();
   
    formData.append("profilePicture", this.form.get('profilePicture').value);
    formData.append("affiliation", this.form.get("affiliation").value);
    formData.append("address", this.form.get('address').value);
    formData.append("userId", this.form.get("userId").value);
   

    this.userService.UploadPersonalData(formData).subscribe((response) => console.log(response),
      (error) => console.log(error));
  }


  
  

  
}
