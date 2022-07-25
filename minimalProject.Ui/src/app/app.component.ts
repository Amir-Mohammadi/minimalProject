import { Component, Input, OnInit, ViewChild } from '@angular/core';
import * as moment from 'moment';
import { AddUserInput, UploadFileResult } from './Models';
import { FileUploadService } from './Services/file-upload.service';
import { UserService } from './Services/user.service';
import { FileUploadComponent } from './shared/file-upload/file-upload.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'app'
  shortLink: string = "";
  loading: boolean = false;
  file?: File  ; 
  firstName: string;
  lastName: string;
  email: string;
  birthDate?: moment.Moment
documentId : string;
  constructor(private userService: UserService,private fileUploadService : FileUploadService ) {
    this.firstName = '';
    this.lastName = '';
    this.email = '';
    this.documentId = ''
  }

  ngOnInit(): void {}

  


  
  //document file


  
  onChange(event : any) {
      this.file = event.target.files[0];
  }


  onUpload() {
      this.loading = !this.loading;
      console.log(this.file);
      this.fileUploadService.upload(this.file).subscribe(
          (event: any) => {
              if (typeof (event) === 'object') {

                  this.shortLink = event.link;
                  this.documentId = this.shortLink
                  this.loading = false; 
              }
          }
      );
  }
  //
  insert() {
    const addUserInput = new AddUserInput();
    addUserInput.FirstName = this.firstName
    addUserInput.LastName = this.lastName
    addUserInput.Email = this.email
    addUserInput.BirthDate = this.birthDate
    addUserInput.Link = this.documentId
    return this.userService.AddUser(addUserInput).subscribe();
  }

}
