import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InsertComponent } from './insert/insert.component';
import { UpdateComponent } from './update/update.component';
import { FormsModule } from '@angular/forms';
import { GetCustomerComponent } from './get-customer/get-customer.component';
import { RouterModule, Routes } from '@angular/router';
import { RouteComponent } from './route/route.component';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';

export const customerRoutes: Routes = [
  {path:'insertCustomer',component:InsertComponent},
  {path:'updateCustomer',component:UpdateComponent},
  {path:'list-Customers',component:ListComponent},
  {path:'customer/:id',component:DetailsComponent},
  {path:'updateCustomer/:id',component:UpdateComponent},
]

@NgModule({
  declarations: [
    InsertComponent,
    UpdateComponent,
    GetCustomerComponent,
    RouteComponent,
    ListComponent,
    DetailsComponent
  
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
  ],
  exports:[
    InsertComponent,
    UpdateComponent,
    RouteComponent
  ]
})
export class CustomerModule { }
