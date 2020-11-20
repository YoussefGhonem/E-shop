import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/_Models/User';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
registerForm:FormGroup;
user:User;
ErrorMsg='';
  constructor(private fp:FormBuilder,private authService:AuthService,private alertify:AlertifyService,
    private router:Router) { }

  ngOnInit():void{
    this.createRegisterForm();
  }

  register(){
      if(this.registerForm.valid){
        this.user=Object.assign({},this.registerForm.value);
        this.authService.rigister(this.user).subscribe(
          ()=>{
            this.alertify.success('Regester Is Done Please Login')
            this.router.navigate(['/login']);
         
          },error => { this.alertify.error(error) }
        )
      }
  }
  createRegisterForm(){
    this.registerForm=this.fp.group({
      username:['',Validators.required],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      email:['',[Validators.email,Validators.required]]
    })
  }
}
