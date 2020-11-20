import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authservice:AuthService,private router:Router,
    private alertify:AlertifyService) {}
  canActivate(next: ActivatedRouteSnapshot,state: RouterStateSnapshot): boolean  {
      if(this.authservice.loggedIn()){
        return true;
      }
      else{
          this.alertify.error("must Be Log-In First");
          return false;
      }
   
  }
  
}
