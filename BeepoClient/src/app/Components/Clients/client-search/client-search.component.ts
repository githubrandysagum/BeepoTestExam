import { Component, OnInit } from '@angular/core';
import { Client } from '../../../Models/client.model';
import { ClientService } from '../../../Services/client.service'
import { AuthService } from 'src/app/Services/auth.service';
import { ActivatedRoute, Router } from '@angular/router'


@Component({
  selector: 'client-search',
  templateUrl: './client-search.component.html',
  styleUrls: ['./client-search.component.css']
})
export class ClientSearchComponent implements OnInit {

  constructor(private _service: ClientService,
    private route: ActivatedRoute,
    private router : Router,
     private _authservice : AuthService) { 

       this.authenticate();
     }

  clients : Client[];
  username : string = ""

  authenticate(){

  

  }

  getClients(): void {
     this._service.Search().subscribe((data : Client[])=> {
      this.clients = data;
     });
  }

  logout(){
    localStorage.removeItem("token");
    this.router.navigate(['/login']);
  }
  ngOnInit() {
    if(localStorage.getItem("token") == null){
      this.router.navigate(['/login']);
    }
    this._authservice.Authenticate()
    .subscribe(data=>{
      this.username = localStorage.getItem("username");

    });
    this.getClients();
    
  }

}
