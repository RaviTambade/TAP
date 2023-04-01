import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { NewPasswordComponent } from './new-password/new-password.component';
import { AssignroleComponent } from './assignrole/assignrole.component';
import { MembershipRoutingComponent } from './membership-routing/membership-routing.component';
import { Route, RouterModule, Routes } from '@angular/router';
import { UpdatePasswordComponent } from './update-password/update-password.component';
import { UpdateEmailComponent } from './update-email/update-email.component';


 export const membershipRoutes: Routes = [
  {path:'login',component:LoginComponent},
  {path:'register',component:RegisterComponent},
  {path:'forgot-password',component:ForgotPasswordComponent},
  {path:'assign-role',component:AssignroleComponent},
  {path:'update-password',component:UpdatePasswordComponent},
  {path:'update-email',component:UpdateEmailComponent},
]
@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    NewPasswordComponent,
    AssignroleComponent,
    MembershipRoutingComponent,
    UpdatePasswordComponent,
    UpdateEmailComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule
  ],
  exports: [
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    AssignroleComponent,
    MembershipRoutingComponent,
  ]
})
export class MembershipModule { }
