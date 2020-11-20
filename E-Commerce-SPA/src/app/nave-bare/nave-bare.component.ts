import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-nave-bare',
  templateUrl: './nave-bare.component.html',
  styleUrls: ['./nave-bare.component.css']
})
export class NaveBareComponent implements OnInit {

  constructor(private fp:FormBuilder,private authService:AuthService,private alertify:AlertifyService,
    private router:Router) { }

  ngOnInit(): void {
  }
  loggedIn(){
    return this.authService.loggedIn();
  }

  loggedOut(){
    localStorage.removeItem('token');
    this.alertify.message('Log out ');
    this.router.navigate(['/home']);
  }

}
