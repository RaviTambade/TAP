import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InsertComponent } from './insert/insert.component';
import { PaymentDetailsComponent } from './payment-details/payment-details.component';
import { ListComponent } from './list/list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { UpdateComponent } from './update/update.component';
import { RoutingComponent } from './routing/routing.component';
import { Route, RouterModule, Routes } from '@angular/router';


const routes: Routes = [
  { path: 'list', component: ListComponent},
  { path: 'insertpayment', component: InsertComponent },
  { path: 'details', component: PaymentDetailsComponent },
  
];

@NgModule({
  declarations: [
    InsertComponent,
    PaymentDetailsComponent,
    ListComponent,
    UpdateComponent,
    RoutingComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forChild(routes)
  ],
  exports:[
    InsertComponent,
    PaymentDetailsComponent,
    ListComponent,
    UpdateComponent,
    RoutingComponent
  ]
})
export class PaymentModule { }
