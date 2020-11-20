import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Product } from "../_models/product";
import { User } from '../_Models/User';
import { AlertifyService } from "../_services/alertify.service";
import { AuthService } from '../_services/auth.service';
import { ProductService } from "../_services/product.service";
import { UserService } from '../_services/user.service';
@Injectable()
export class UserEditResolver implements Resolve<User>{
    constructor(private service:UserService,private authService:AuthService,private router:Router,private alertify:AlertifyService){}
    resolve(route: ActivatedRouteSnapshot): Observable<User> {
       return this.service.getUser(this.authService.decodedToken.nameid).pipe(
        catchError(
            error=>{
                this.alertify.error(' can not load edit resolver');
                this.router.navigate(['/products']);
                return of(null);
            }
        ))
    }



}