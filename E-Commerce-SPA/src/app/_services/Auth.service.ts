import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { from } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from 'src/app/_Models/User';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private Http: HttpClient) { }
  baseURL = environment.apiUrl + 'Auth/';

  jwtHelper = new JwtHelperService();// علشان يعرف هل التوكين ده صح ولا لا 
  decodedToken: any; // لفك تشفير التوكين علشان اخد المعلومات الخاصه باليوزر
  currentUser: User;

  login(model: any) {
    return this.Http.post(this.baseURL + 'login', model).pipe( // use pip becouse api return values(token,user)
      map(
        (response: any) => {
          const user = response;//all data from Api
          if (user) {
            //و هنا باخد الحجات اللي جايه من الدوت نت واعملها حفظ ف اللوكال استوريدج
            localStorage.setItem('token', user.token);  // save token from api in localStorage
            localStorage.setItem('user', JSON.stringify(user.user)) // save user info from api in localStorage
            // لفك تشفير التوكين علشان اخد المعلومات الخاصه باليوزر
            this.decodedToken = this.jwtHelper.decodeToken(user.token);
            // save user info from api in variable
            this.currentUser = user.user;
          }
        }))
  }

  loggedIn() {
    try {
      const token = localStorage.getItem('token');
      return !this.jwtHelper.isTokenExpired(token);
    }
    catch {
      return false;
    }
  }

  rigister(user:User){
    return this.Http.post(this.baseURL+'register',user);
  }

}
