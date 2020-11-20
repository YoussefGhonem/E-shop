import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/_Models/product';
import { User } from 'src/app/_Models/User';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
user:User;
myProduct:Product[];
@ViewChild('userEdit')userEdit:NgForm;
  constructor(private router:ActivatedRoute,private userService:UserService,private auth:AuthService,private alertify:AlertifyService) { }

  ngOnInit(): void {
    this.router.data.subscribe(
      data=>{this.user=data['user']}
    );
    this.router.data.subscribe(
      data=>{this.myProduct=data['myproduct']}
    );
  }
  UpdateUser(){
this.userService.updateUser(this.auth.decodedToken.nameid,this.user).subscribe(
  ()=>{
    this.alertify.success("Updated Is Done");
    this.userEdit.reset(this.user);
  },
  er=>{this.alertify.error('Sorry Can not Save Change')}
)
  }
}
