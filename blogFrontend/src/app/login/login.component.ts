import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { FormControl, FormGroup } from '@angular/forms';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{
  constructor(
    private title: Title,
    private user: UserService,
    private router: Router){}
  ngOnInit(){
    this.title.setTitle("Login");
  }

  LoginForm = new FormGroup({
    Username: new FormControl(''),
    Password: new FormControl('')
  })

  Login(){
    this.user.loginUser(this.LoginForm.value).subscribe((result)=>{
      if(result=="Authenticated"){
        this.router.navigate(['/'])
      }
      },
      (error)=>{
        if(error.error=='User Not Found'){
          Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Incorrect Username or Password!'
          }).then((okay)=>{
            if(okay){
              this.router.navigate(['/login'])
            }
          })
        }
      }
    )
  }
}
