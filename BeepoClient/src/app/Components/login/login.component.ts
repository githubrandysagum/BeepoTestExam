import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { ActivatedRoute, Router } from '@angular/router'

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private _authservice : AuthService,
    private route: ActivatedRoute,
    private router : Router
    ) { }

  username : string = "";
  password : string ="";

  ngOnInit() {
  }

  login() : void {
    this._authservice.Login(this.username, this.password)
      .subscribe(data =>{
        localStorage.setItem("token", data);
        localStorage.setItem("username",this.username);
        this.router.navigate(['/clients']);
      })
  }

}
