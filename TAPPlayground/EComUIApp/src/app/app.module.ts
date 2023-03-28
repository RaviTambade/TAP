import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AccountModule } from './account/account.module';
import { RouterModule, Routes } from '@angular/router';
import { MembershipModule } from './membership/membership.module';
import { SuppliersModule } from './suppliers/suppliers.module';
import { AppComponent } from './app.component';
import { DatePipe } from '@angular/common';
import { CustomerModule } from './customer/customer.module';
import { HttpClientModule } from '@angular/common/http';
import { TransactionModule } from './transaction/transaction.module';
import { PaymentModule } from './payment/payment.module';


//metadata
//decorator


const routes: Routes = [

]
@NgModule({
  declarations: [
    AppComponent
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    DatePipe,
    TransactionModule,
    AccountModule, 
    MembershipModule,
    SuppliersModule,
    CustomerModule,
    PaymentModule,
    RouterModule.forRoot(routes),
    DatePipe,

  ],
  providers: [DatePipe],
  bootstrap: [AppComponent] //Root Component
})
export class AppModule { } //Root Module

//What do you mean by Angular Module ?
//it is like namespace  or package
//it consist of
//Basic building blocks:
// components, services, directives, pipes, decorators
// interface,classes
