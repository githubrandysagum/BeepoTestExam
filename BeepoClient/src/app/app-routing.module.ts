import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClientSearchComponent } from './Components/Clients/client-search/client-search.component'
import { ClientFormComponent } from './Components/Clients/client-form/client-form.component'
import { LoginComponent } from './Components/login/login.component';



const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'Home/Index', component: LoginComponent },
  { path: 'Home', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  { path: 'client', component: ClientFormComponent },
  { path: 'clients', component: ClientSearchComponent },
  { path: 'clients/:id/:editdel', component: ClientFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
