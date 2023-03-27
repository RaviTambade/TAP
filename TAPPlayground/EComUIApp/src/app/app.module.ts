import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
<<<<<<< HEAD
import { HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { TransactionModule } from './transaction/transaction.module';
=======
import { Account } from './account/account';
import { AccountModule } from './account/account.module';
import { RouterModule, Routes } from '@angular/router';
import { MembershipModule } from './membership/membership.module';
import { SuppliersModule } from './suppliers/suppliers.module';
import { AppComponent } from './app.component';
>>>>>>> 5b8dfd92446919e935e6564dd47f06a76890d3ef
import { DatePipe } from '@angular/common';

//metadata
//decorator


const routes: Routes = [

]
@NgModule({
  declarations: [
<<<<<<< HEAD
    AppComponent,
=======
    AppComponent
    
>>>>>>> 5b8dfd92446919e935e6564dd47f06a76890d3ef
  ],
  imports: [
    BrowserModule,
    FormsModule,
<<<<<<< HEAD
    HttpClientModule,
    DatePipe,
    TransactionModule
=======
    AccountModule, 
    MembershipModule,
    SuppliersModule,
    RouterModule.forRoot(routes),
    DatePipe

>>>>>>> 5b8dfd92446919e935e6564dd47f06a76890d3ef
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
