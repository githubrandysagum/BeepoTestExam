import { Injectable } from '@angular/core';
import {Client} from  '../Models/client.model';
import { HttpClient } from '@angular/common/http';
import {  HttpHeaders, HttpParams } from '@angular/common/http';
import { WebApiHost}  from '../WepApiHost';
import { Observable } from 'rxjs';
import { PLATFORM_WORKER_APP_ID } from '@angular/common/src/platform_id';
import { ThrowStmt } from '@angular/compiler';

@Injectable({
  providedIn: 'root',
})
export class ClientService {

  constructor(private http : HttpClient) { }
  wepApi = new WebApiHost(); 
  url = this.wepApi.host+ 'api/clients';
  

  Search () : Observable<Client[]> {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization :"Bearer "+ localStorage.getItem("token")
    });
    return this.http.get<Client[]>(this.url, { headers: headers});
  }

  Get(id : number) : Observable<Client> {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization :"Bearer "+ localStorage.getItem("token")
    });
    return this.http.get<Client>(this.url +'\\'+ id, {headers: headers});
  }

  Post(client: Client): Observable<Client>{
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization :"Bearer "+ localStorage.getItem("token")
    });
    const requestOptions = {                                                                                                                                                                                 
      headers: headers
    };
    let body = client;
    return this.http.post<Client>(this.url, body, requestOptions);
  }

  Put(client: Client): Observable<Client>{

   let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization :"Bearer "+ localStorage.getItem("token")
    });
    let body = client;
    return this.http.put<Client>(this.url, body, {headers: headers});
  }

  Delete(id: number): Observable<Client>{
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization :"Bearer "+ localStorage.getItem("token")
    });
    return this.http.delete<Client>(this.url + '\\'+ id, {headers: headers});
  }

}