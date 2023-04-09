import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewcartComponent } from './viewcart/viewcart.component';



@NgModule({
  declarations: [
    ViewcartComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    ViewcartComponent
  ]
})
export class CartModule { }
