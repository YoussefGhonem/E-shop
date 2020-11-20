// Module
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FileUploader, FileUploadModule } from 'ng2-file-upload';
// Ngx Gallery
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
// Guards
import{AuthGuard} from'./_guard/auth.guard';
import{LoginGuard} from'./_guard/login.guard';
import{PreventUnsaveGuard} from'./_guard/prevent-unsave.guard';
import{UserEditPreventUnsaveGuard} from'./_guard/user-edit-prevent-unsave.guard';


// JWt
import { JwtModule } from '@auth0/angular-jwt';
// Ngx-Bootstrab
import { TabsModule } from 'ngx-bootstrap/tabs';
//Services
import{ProductService}from'./_services/product.service'
import { AlertifyService } from './_services/alertify.service';
import { ErrorInterceptorProvidor } from './_services/error.interceptor';
import { AuthService } from './_services/auth.service';
import{UserService}from './_services/user.service'
//Resolver
import {ProductDetailResolver}from'src/app/_Resolvers/product-detail.resolver';
import{ProductListResolver}from'src/app/_Resolvers/product-list.resolver';
import{ProductEditResolver}from'src/app/_Resolvers/product-edit.resolver';
import{MypProductListResolver}from'src/app/_Resolvers/myproduct-list.resolver';
import{UserEditResolver}from'src/app/_Resolvers/user-edit.resolver';
// Component
import { ProductListComponent } from './Products/product-list/product-list.component';
import { ProductDetailComponent } from './Products/product-detail/product-detail.component';
import { ProductCardComponent } from './Products/product-card/product-card.component';
import { FavoritsComponent } from './favorits/favorits.component';
import { MessagesComponent } from './messages/messages.component';
import { HomeComponent } from './home/home.component';
import { AppComponent } from './app.component';
import { NaveBareComponent } from './nave-bare/nave-bare.component';
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './Account/register/register.component';
import { ProductEditComponent } from './Products/product-edit/product-edit.component';
import { UserEditComponent } from './Users/user-edit/user-edit.component';
import { PhotoEditorComponent } from './Products/photo-editor/photo-editor.component';


// JWT Setting // هنا علشان ابعت التوكين لكل ريكويست من الدوت نت 
export function tokenGetter() {
  return localStorage.getItem('token');
}
@NgModule({
  declarations: [
    AppComponent,
    NaveBareComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    FavoritsComponent,
    MessagesComponent,
    ProductListComponent,
    ProductDetailComponent,
    ProductCardComponent,
    ProductEditComponent,
    UserEditComponent,
    PhotoEditorComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule, //Reactive Validation
    AppRoutingModule,
    HttpClientModule,//HttpClient
    TabsModule.forRoot(),// Ngx-Bootstrab  Tab
  
    JwtModule.forRoot({ // JWT  // هنا علشان ابعت التوكين لكل ريكويست من الدوت نت 
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: ['localhost:5000/auth']// هنا مش هياخد التوكين معاه علشان مش هحتاجه ف التسجيل او اللوجين
      }
    }),
    NgxGalleryModule,
    FileUploadModule // ng2-file-upload
    

  ],
  providers: // Services , Guards , Resolvers
    [AuthService,
    ErrorInterceptorProvidor,
    AlertifyService ,
    FormsModule,
    AuthGuard ,
    LoginGuard,
    ProductService,
    ProductDetailResolver,
    ProductListResolver,
    UserService,
    ProductEditResolver,
    UserEditResolver,
    MypProductListResolver,
    PreventUnsaveGuard,
    UserEditPreventUnsaveGuard
  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
