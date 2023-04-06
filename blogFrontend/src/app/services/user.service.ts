import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../env/env.development'

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  baseApiUrl: string = environment.baseApiUrl;

  registerUser(user:any){
    return this.http.post(
      this.baseApiUrl + 'api/User/Register', user,{responseType:'text'}
    );
  }
}
