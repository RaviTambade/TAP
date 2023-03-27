import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TransactionListComponent } from './transaction-list/transaction-list.component';
import { FormsModule } from '@angular/forms';
import { TransactiondetailsComponent } from './transactiondetails/transactiondetails.component';
import { InserttransactionComponent } from './inserttransaction/inserttransaction.component';
import { UpdatetransactionComponent } from './updatetransaction/updatetransaction.component';
import { GetTransactionComponent } from './get-transaction/get-transaction.component';
import { DetailsComponent } from './details/details.component';
import { SearchComponent } from './search/search.component';




@NgModule({
  declarations: [
    TransactionListComponent,
    TransactiondetailsComponent,
    InserttransactionComponent,
    UpdatetransactionComponent,
    GetTransactionComponent,
    DetailsComponent,
    SearchComponent,
  ],
  exports:[
    TransactionListComponent,
    TransactiondetailsComponent,
    InserttransactionComponent,
    UpdatetransactionComponent,
    GetTransactionComponent,
    DetailsComponent,
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class TransactionModule { }
