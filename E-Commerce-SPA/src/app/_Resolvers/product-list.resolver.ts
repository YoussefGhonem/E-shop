import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Product } from "../_models/product";
import { AlertifyService } from "../_services/alertify.service";
import { ProductService } from "../_services/product.service";
@Injectable()
export class ProductListResolver  implements Resolve<Product[]>{
    
    constructor(private productServices:ProductService,private alertify:AlertifyService,private route:Router){     }

    resolve(route: ActivatedRouteSnapshot):Observable<Product[]> {
        return this.productServices.getProducts().pipe(
            catchError(
                err=>{
                    this.alertify.error('Can not load Product List');
                    this.route.navigate[''];
                    return of(null);
                }
            )
        )
    }

}