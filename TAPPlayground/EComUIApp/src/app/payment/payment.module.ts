import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InsertComponent } from './insert/insert.component';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';



@NgModule({
  declarations: [
    InsertComponent,
    ListComponent,
    DetailsComponent
  ],
  imports: [
    CommonModule
  ]
})
export class PaymentModule { }
