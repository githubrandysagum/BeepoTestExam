import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../../Services/client.service';
import {Client } from '../../../Models/client.model';
import { ActivatedRoute, Router } from '@angular/router'

@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit {

  constructor(
    private service : ClientService, 
    private route: ActivatedRoute,
    private router : Router) { }

  editNewOpt = false;
  deleteOpt = false;
  editdel = 0;
  id = 0;
  client : Client = {
    intClientId : 0,
    strClientId : "",
    strFirstName : "",
    strLastName : "",
    strAddress : "",
    strEmail : "",
    strPhoneNumber : "",
    dtmBirthDate : ""
  };
  error : {
    intClientId : [],
    strClientId : [],
    strFirstName : [],
    strLastName : [],
    strAddress : [],
    strEmail : [],
    strPhoneNumber : [],
    dtmBirthDate : [],
  };

  ngOnInit() {
    this.route.params.subscribe(params => {

      this.id = +params['id']; // (+) converts string 'id' to a number
      this.editdel = +params['editdel'];

      if(this.editdel==2){
        this.deleteOpt = true;
      }else{
        this.editNewOpt = true;
      }

      if(this.id>0){
        this.get(this.id);
      }
   });

  }

  get(id : number) : void {
    this.service.Get(id)
      .subscribe(data=>{
        this.client = data;
      })
  }



  delete() : void {
    this.service.Delete(this.id).subscribe(result=>{
      this.router.navigate(['/clients']);
    });
  }

  cancel () : void{
    this.router.navigate(['/clients']);
  }
  save() : void {
    if(this.id > 0){
      debugger
      this.service.Put(this.client)
      .subscribe(result => {
        this.router.navigate(['/clients']);
      },errorResult=>{
        debugger
        this.error = errorResult.error["ModelState"];
      });
    }else{
      debugger

      this.service.Post(this.client)
      .subscribe(result => {
        this.router.navigate(['/clients']);
      },errorResult=>{
        this.error = errorResult.error["ModelState"];
      });
    }
  }
}
