import { Injectable } from '@angular/core';
import {WebApiHost} from  '../WepApiHost';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  wepApi = new WebApiHost();
  constructor(private http : HttpClient) { }
  url = this.wepApi.host + 'api/Authentication';
  
  Authenticate() : Observable<boolean> {

    
    let token = localStorage.getItem("token");
    let params = new HttpParams();
      params.set("token", token);
    let headers = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded',
      Authorization :"Bearer "+token,
    });

     return this.http.get<boolean>(this.url, { headers:headers, params : params});
  }

  Login(user : string , password : string) : Observable<string>{
    let token = localStorage.getItem("token");
    let headers = new HttpHeaders({
      Authorization :"Bearer "+token, 
    });
    
      headers.append('Content-Type', 'application/x-www-form-urlencoded');
      let params = new HttpParams();
     
      let body = {
        strUserName: user,
        strPassword : password
      }

      const requestOptions = {                                                                                                                                                                                 
        headers: headers, 
        params : params
      };


      return this.http.post<string>(this.wepApi.host +"api/login",body, requestOptions);
  }


}