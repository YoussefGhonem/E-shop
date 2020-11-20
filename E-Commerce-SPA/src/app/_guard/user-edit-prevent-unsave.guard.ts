import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';
import { UserEditComponent } from '../Users/user-edit/user-edit.component';
import { AlertifyService, ConfirmResult } from '../_services/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class UserEditPreventUnsaveGuard implements CanDeactivate<UserEditComponent> {
  x = false;
  constructor(private alertify: AlertifyService) { }
 async canDeactivate(component: UserEditComponent) {
  if (component.userEdit.dirty) {

    const confirm = await this.alertify.promisifyConfirm('Are You Sure Leave This Page', 'Alert  ');
    if (confirm == ConfirmResult.Ok) { this.x = true } else {
      this.x = false;
    }
    return this.x;

  }
   return true
  }

}
  

