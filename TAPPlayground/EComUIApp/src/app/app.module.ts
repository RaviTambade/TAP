import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
<<<<<<< HEAD
import { HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { TransactionModule } from './transaction/transaction.module';
=======
>>>>>>> 8b9664d20ad8ffcd6a9d3aaa994654477556d1b0
import { AccountModule } from './account/account.module';
import { RouterModule, Routes } from '@angular/router';
import { MembershipModule } from './membership/membership.module';
import { SuppliersModule } from './suppliers/suppliers.module';
<<<<<<< HEAD
import { DatePipe } from '@angular/common';
=======
import { AppComponent } from './app.component';
import { DatePipe } from '@angular/common';
import { CustomerModule } from './customer/customer.module';
import { HttpClientModule } from '@angular/common/http';
import { TransactionModule } from './transaction/transaction.module';

>>>>>>> 8b9664d20ad8ffcd6a9d3aaa994654477556d1b0
//metadata
//decorator


const routes: Routes = [

]
@NgModule({
  declarations: [
<<<<<<< HEAD
    AppComponent
=======
    AppComponent,
    AppComponent
    
>>>>>>> 8b9664d20ad8ffcd6a9d3aaa994654477556d1b0
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
    
    RouterModule.forRoot(routes),
    DatePipe
<<<<<<< HEAD
=======

>>>>>>> 8b9664d20ad8ffcd6a9d3aaa994654477556d1b0
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
