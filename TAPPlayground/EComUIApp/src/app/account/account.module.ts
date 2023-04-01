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
import { AccountRoutingComponent } from './account-routing/account-routing.component';
import { Routes,RouterModule } from '@angular/router';



export const accountRoutes:Routes=[
  {path:'accounts',component:ListComponent},
  {path:'searchAccount',component:SearchAccountComponent},
  {path:'account/:id',component:DetailsComponent},
  {path:'insertAccount',component:InsertComponent},
  {path:'updateAccount/:id',component:UpdateComponent},

]


@NgModule({
  declarations: [
    ListComponent,
    DetailsComponent,
    AccountdetailsComponent,
    InsertComponent,
    UpdateComponent,
    SearchAccountComponent,
    AccountRoutingComponent,
    
    ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    DatePipe,
    RouterModule,

  ],
  exports:[
    // ListComponent,
    // DetailsComponent,
    // AccountdetailsComponent,
    // InsertComponent,
    // UpdateComponent,
    // SearchAccountComponent,
    AccountRoutingComponent
    
    
  ]
})
export class AccountModule { }
