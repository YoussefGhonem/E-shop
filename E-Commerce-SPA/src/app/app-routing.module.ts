import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './Account/register/register.component';
import { HomeComponent } from './home/home.component';
import { ProductDetailComponent } from './Products/product-detail/product-detail.component';
import { ProductEditComponent } from './Products/product-edit/product-edit.component';
import { ProductListComponent } from './Products/product-list/product-list.component';
import { UserEditComponent } from './Users/user-edit/user-edit.component';
import { AuthGuard } from './_guard/auth.guard';
import { LoginGuard } from './_guard/login.guard';
import { PreventUnsaveGuard } from './_guard/prevent-unsave.guard';
import { UserEditPreventUnsaveGuard } from './_guard/user-edit-prevent-unsave.guard';
import { MypProductListResolver } from './_Resolvers/myproduct-list.resolver';
import { ProductDetailResolver } from './_Resolvers/product-detail.resolver';
import { ProductEditResolver } from './_Resolvers/product-edit.resolver';
import { ProductListResolver } from './_Resolvers/product-list.resolver';
import { UserEditResolver } from './_Resolvers/user-edit.resolver';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent,canActivate:[LoginGuard] },
  { path: 'register', component: RegisterComponent ,canActivate:[LoginGuard]},
  { path: 'user/edit', component: UserEditComponent ,resolve:{user:UserEditResolver,myproduct:MypProductListResolver},canDeactivate:[UserEditPreventUnsaveGuard]},
  { path: 'products', component: ProductListComponent ,resolve:{products:ProductListResolver}},
  { path: 'product/edit/:id', component: ProductEditComponent ,canDeactivate:[PreventUnsaveGuard],resolve:{product:ProductEditResolver}},
  { path: 'product/:id', component: ProductDetailComponent ,resolve:{product:ProductDetailResolver}},









  
  { path: '**', redirectTo :'',pathMatch:'full'},// في حاله لو شخص بيكتب روابط غريبه
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
