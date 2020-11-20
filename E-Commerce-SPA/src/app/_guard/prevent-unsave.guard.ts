import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';
import { ProductEditComponent } from '../Products/product-edit/product-edit.component';
import { UserEditComponent } from '../Users/user-edit/user-edit.component';
import { AlertifyService, ConfirmResult } from '../_services/alertify.service';

@Injectable({
  providedIn: 'root'
})

// هنا لو انت حاولت تطلع من الصفحه من غير ما تعمل حفظ للتعديلات
export class PreventUnsaveGuard implements CanDeactivate<ProductEditComponent> {
  x = false;
  constructor(private alertify: AlertifyService) { }

  async canDeactivate(component: ProductEditComponent){
    
    if (component.productEdit.dirty) {

      const confirm = await this.alertify.promisifyConfirm('Are You Sure Leave This Page', 'Alert  ');
      if (confirm == ConfirmResult.Ok) { this.x = true } else {
        this.x = false;
      }
      return this.x;

    }
    return true
  }

  }
  

