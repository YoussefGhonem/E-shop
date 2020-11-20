import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Product } from "../_models/product";
import { User } from '../_Models/User';
import { AlertifyService } from "../_services/alertify.service";
import { ProductService } from "../_services/product.service";
@Injectable()
export class ProductEditResolver implements Resolve<Product>{
    constructor(private productServices:ProductService,private alertify:AlertifyService,private route:Router){     }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot):  Observable<Product>  {
        return this.productServices.getProduct(route.params['id']).pipe(
            catchError(
                err=>{
                    this.alertify.error(' can not load Product Edit resolver');
                    //this.route.navigate(['/products']);
                    return of(null);
                }
            )
        )

    }




}