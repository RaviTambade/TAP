import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { TransactionModule } from './transaction/transaction.module';
import { AccountModule } from './account/account.module';
import { RouterModule, Routes } from '@angular/router';
import { MembershipModule } from './membership/membership.module';
import { SuppliersModule } from './suppliers/suppliers.module';
import { DatePipe } from '@angular/common';
import { CustomerModule } from './customer/customer.module';
import { ProductsModule } from './product/products.module';



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
    ProductsModule,
    RouterModule.forRoot(routes),
    DatePipe
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
