import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostService } from '../services/post.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent {
  constructor(
    private route: ActivatedRoute,
    private post: PostService,
    private title: Title
  ) {}

  noPosts: boolean = false;
  username: any;
  posts: any;

  ngDoCheck() {
    this.title.setTitle('My Profile | ' + this.username);
  }

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      this.username = params.get('username');
      if (this.username) {
        this.post.getPostsByAuthor(this.username).subscribe(
          (result) => {
            this.posts = result;
          },
          (error) => {
            if (error.error == 'No Posts') {
              this.noPosts = true;
            }
          }
        );
      }
    });
  }
}
