import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class FileManagerService  {
  constructor( protected http: HttpClient) {
  }

  uploadFile(formData: any, options: any = null) {
    const url = "uploadFile"
    return this.http.post<any>(url, formData);
  }
}
