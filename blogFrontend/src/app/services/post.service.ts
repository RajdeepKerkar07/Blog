import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/env/env.development';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  baseApiUrl: string = environment.baseApiUrl;

  post(post:any){
    return this.http.post(
      this.baseApiUrl + 'api/Post/CreatePost', post, {responseType:'text'}
    )
  }
  getPosts(){
    return this.http.get(
      this.baseApiUrl + 'api/Post/GetAllPosts'
    )
  }
}
