import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InsertComponent } from './insert/insert.component';
import { UpdateComponent } from './update/update.component';
import { FormsModule } from '@angular/forms';
import { GetCustomerComponent } from './get-customer/get-customer.component';



@NgModule({
  declarations: [
    InsertComponent,
    UpdateComponent,
    GetCustomerComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports:[
    InsertComponent,
    UpdateComponent
  ]
})
export class CustomerModule { }
