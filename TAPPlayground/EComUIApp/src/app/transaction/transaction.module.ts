import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { TransactionListComponent } from './transaction-list/transaction-list.component';
import { FormsModule } from '@angular/forms';
import { TransactiondetailsComponent } from './transactiondetails/transactiondetails.component';
import { InserttransactionComponent } from './inserttransaction/inserttransaction.component';
import { UpdatetransactionComponent } from './updatetransaction/updatetransaction.component';
import { GetTransactionComponent } from './get-transaction/get-transaction.component';
import { DetailsComponent } from './details/details.component';
import { SearchComponent } from './search/search.component';
import { RoutingComponent } from './routing/routing.component';
import { RouterModule,Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

const routes: Routes = [
  {path:'transaction-list',component:TransactionListComponent},
  //{path:'search',component:SearchComponent},
  {path:'inserttransaction',component:InserttransactionComponent},
  {path:'updatetransaction',component:UpdatetransactionComponent}
  // {path:'delete',component:UpdatetransactionComponent},
]

@NgModule({
  declarations: [
    TransactionListComponent,
    TransactiondetailsComponent,
    InserttransactionComponent,
    UpdatetransactionComponent,
    GetTransactionComponent,
    DetailsComponent,
    SearchComponent,
    RoutingComponent,
  ],
  exports:[
    RoutingComponent,
    TransactionListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    DatePipe,
    RouterModule.forChild(routes)
  ]
})
export class TransactionModule { }
