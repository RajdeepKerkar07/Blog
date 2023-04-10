import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  isLoggedIn: boolean = false;
  user: any;

  constructor(private router: Router) {}

  ngDoCheck() {
    this.checkStrorage();
  }

  checkStrorage() {
    if (localStorage.getItem('username') != null) {
      this.isLoggedIn = true;
      this.user = localStorage.getItem('username');
    }
  }

  logout() {
    localStorage.clear();
    this.isLoggedIn = false;
    this.router.navigate(['/login']);
  }
}
