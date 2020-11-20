import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    constructor(private fp:FormBuilder,private authService:AuthService,private alertify:AlertifyService,
      private router:Router) { }
      loginForm:FormGroup;
      model:any={};
      ErrorMsg:string;
  ngOnInit(): void {
    this.ErrorMsg='';
  }

  login(){
    this.authService.login(this.model).subscribe(
      next=>{this.alertify.success(' Login Success')},
      error=>{this.alertify.error(error)},
      ()=>{this.router.navigate(['/home']);}
    )
  }



}
