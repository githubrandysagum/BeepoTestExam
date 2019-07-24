import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule }    from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientSearchComponent } from './Components/Clients/client-search/client-search.component';
import { ClientFormComponent } from './Components/Clients/client-form/client-form.component'; 
import { LoginComponent } from './Components/login/login.component';
import { ClientService } from './Services/client.service';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthService } from './Services/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    ClientSearchComponent,
    ClientFormComponent,
    LoginComponent,
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [ClientService, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
