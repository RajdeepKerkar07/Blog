import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { PostService } from '../services/post.service';
import Swal from 'sweetalert2';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  constructor(private postService: PostService, private title: Title) {}

  user: any;
  posts: any;
  ngDoCheck() {
    this.user = localStorage.getItem('username');
    this.postForm.controls.author.setValue(this.user);
  }
  ngOnInit() {
    this.title.setTitle('Home');
    this.postService.getPosts().subscribe((response) => {
      this.posts = response;
    });
  }

  postForm = new FormGroup({
    title: new FormControl(''),
    description: new FormControl(''),
    author: new FormControl(''),
  });

  post() {
    this.postService.post(this.postForm.value).subscribe(
      (response) => {
        if (response == 'Post Created') {
          Swal.fire({
            icon: 'success',
            title: 'Success',
            text: 'Post has been created successfully',
          });
          this.postForm.reset();
        }
      },
      (error) => {
        Swal.fire({
          icon: 'error',
          title: 'OOPS',
          text: 'Something went wrong',
        });
      }
    );
  }
}
