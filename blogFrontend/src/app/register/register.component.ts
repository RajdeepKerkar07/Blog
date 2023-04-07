import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  constructor(
    private title: Title,
    private user: UserService,
    private router: Router
    ){}
  ngOnInit(){
    this.title.setTitle("Register");
  }

  RegisterForm = new FormGroup({
    firstname: new FormControl(''),
    lastname: new FormControl(''),
    username: new FormControl(''),
    password: new FormControl('')
  })

  Register(){
    this.user.registerUser(this.RegisterForm.value).subscribe((result)=>{
      if(result=="Account Created"){
        Swal.fire({
          icon:'success',
          title: 'Success',
          text:'Your account has been created successfully!'
        }).then((okay)=>{
          if(okay){
            this.router.navigate(['/login'])
          }
        })
      }
      },
      (error)=>{
        if(error.error=='Account already exists'){
          Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Try again with a different username!'
          }).then((okay)=>{
            if(okay){
              this.router.navigate(['/register'])
            }
          })
        }
      }
    )
  }
}
