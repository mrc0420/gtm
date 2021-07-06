import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpEventType} from '@angular/common/http';

@Component({
  selector: 'app-image',
  templateUrl: './image.component.html',
  styleUrls: ['./image.component.css']
})
export class ImageComponent implements OnInit {
  selectedImage: File;
    progress: number;
    message: string;
  constructor(private http:HttpClient) { }

  ngOnInit() {
  }
  public upload(event): void {
    this.selectedImage = event.target.files[0];
    //var formData = new FormData();
    //formData.append("ProfilePicture", this.selectedImage, this.selectedImage.name);
    this.http.post("http://localhost:56186/api/users/upload/image", this.selectedImage).subscribe();


  }
  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.http.post('http://localhost:56186/api/users/upload/image', formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
        }
      });
  }

}
