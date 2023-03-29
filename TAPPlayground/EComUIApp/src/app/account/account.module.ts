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



const routes:Routes=[
  {path:'accountsList',component:ListComponent},
  // {path:'account/:id',component:SearchAccountComponent},
  {path:'account/:id',component:AccountdetailsComponent},
  {path:'insertAccount',component:InsertComponent},
  {path:'updateAccount',component:UpdateComponent},
  {path:'account/update',component:UpdateComponent},

]


@NgModule({
  declarations: [
    ListComponent,
    DetailsComponent,
    AccountdetailsComponent,
    InsertComponent,
    UpdateComponent,
    SearchAccountComponent,
    AccountRoutingComponent
    ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    DatePipe,
    RouterModule.forChild(routes),

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
