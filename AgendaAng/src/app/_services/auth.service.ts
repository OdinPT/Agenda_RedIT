import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { Contacto } from '../_models/Contacto';
import { Employee } from '../_models/Employee';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
 baseUrl = environment.apiUrl + 'auth/';
 jwtHelper = new JwtHelperService();
 decodedToken: any;


constructor(private http: HttpClient) { }

login(model: any) {
  return this.http.post(this.baseUrl + 'login', model).pipe(
    map((response: any) => {
      const user = response;
      if (user) {
        localStorage.setItem('token', user.token);
        localStorage.setItem('user', model.username);
        localStorage.setItem('userid', user.userid);
        this.decodedToken = this.jwtHelper.decodeToken(user.token);
      }
    })
   );
 }

 register(employee: Employee) {
   return this.http.post(this.baseUrl + 'register', employee);
 }

 loggedIn() {
  const token = localStorage.getItem('token');
  return !this.jwtHelper.isTokenExpired(token) ;
}
 
}
