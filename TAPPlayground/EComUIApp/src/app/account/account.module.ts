import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { HttpClientModule } from '@angular/common/http';
import { DetailsComponent } from './details/details.component';
import { FormsModule } from '@angular/forms';
import { AccountdetailsComponent } from './accountdetails/accountdetails.component';



@NgModule({
  declarations: [
    ListComponent,
    DetailsComponent,
    AccountdetailsComponent
    ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule

  ],
  exports:[
    ListComponent,
    DetailsComponent,
    AccountdetailsComponent,
    
  ]
})
export class AccountModule { }
