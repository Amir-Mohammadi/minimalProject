import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AddUserInput } from '../Models';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  AddUser(addUserInput: AddUserInput) {
    const url = 'User/AddUser';
    return this.http.post(`${environment.apiUrl}/${url}`, addUserInput);
  }
  public OnUploadFile() {}
}
