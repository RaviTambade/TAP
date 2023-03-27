import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { ListComponent } from './list/list.component';
import { HttpClientModule } from '@angular/common/http';
import { DetailsComponent } from './details/details.component';
import { FormsModule } from '@angular/forms';
import { AccountdetailsComponent } from './accountdetails/accountdetails.component';
import { InsertComponent } from './insert/insert.component';
import { UpdateComponent } from './update/update.component';
import { SearchAccountComponent } from './search-account/search-account.component';



@NgModule({
  declarations: [
    ListComponent,
    DetailsComponent,
    AccountdetailsComponent,
    InsertComponent,
    UpdateComponent,
    SearchAccountComponent
    ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    DatePipe

  ],
  exports:[
    ListComponent,
    DetailsComponent,
    AccountdetailsComponent,
    InsertComponent,
    UpdateComponent,
    SearchAccountComponent
    
    
  ]
})
export class AccountModule { }
