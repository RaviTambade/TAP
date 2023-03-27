import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { Account } from './account/account';
import { AccountModule } from './account/account.module';
import { RouterModule, Routes } from '@angular/router';
<<<<<<< HEAD
import { AppComponent } from './app.component';
=======
>>>>>>> 7192d75a2cb5f846d4127886880d9246e3a480de
import { MembershipModule } from './membership/membership.module';
import {AppComponent} from './app.component';
import { SuppliersModule } from './suppliers/suppliers.module';
import { DatePipe } from '@angular/common';

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
    AccountModule, 
    MembershipModule,
    SuppliersModule,
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
