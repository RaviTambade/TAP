import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InsertComponent } from './insert/insert.component';
import { PaymentDetailsComponent } from './payment-details/payment-details.component';
import { ListComponent } from './list/list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    InsertComponent,
    PaymentDetailsComponent,
    ListComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule
  ],
  exports:[
    InsertComponent,
    PaymentDetailsComponent,
    ListComponent
  ]
})
export class PaymentModule { }
