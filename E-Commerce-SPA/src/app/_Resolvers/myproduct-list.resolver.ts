import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Product } from "../_models/product";
import { AlertifyService } from "../_services/alertify.service";
import { AuthService } from '../_services/auth.service';
import { ProductService } from "../_services/product.service";
@Injectable()
export class MypProductListResolver  implements Resolve<Product[]>{
    
    constructor(private productServices:ProductService,private alertify:AlertifyService,private router:Router,private auth:AuthService){     }
    resolve(route: ActivatedRouteSnapshot): Observable<Product[]>  {
        return this.productServices.getMyProducts(this.auth.decodedToken.nameid).pipe(
            catchError(err=>{
                this.alertify.error(' can not load my Product resolver');
                //this.router.navigate(['/products']);
                return of(null);
            })
        )
    }

   

}