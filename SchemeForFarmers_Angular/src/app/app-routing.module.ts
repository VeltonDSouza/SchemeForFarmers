import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {FarmerRegistrationComponent} from './farmer-registration/farmer-registration.component'
import {BidderRegistrationComponent} from './bidder-registration/bidder-registration.component'
import  {LoginComponent} from './login/login.component'
const routes: Routes = [
  {path:'farmerSignup',component:FarmerRegistrationComponent},
  {path:'bidderSignup',component:BidderRegistrationComponent},
  {path:'logIn',component:LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
