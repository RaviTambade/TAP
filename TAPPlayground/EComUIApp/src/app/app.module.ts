import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { MembershipModule } from './membership/membership.module';

//metadata
//decorator
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    MembershipModule
  ],
  providers: [],
  bootstrap: [AppComponent] //Root Component
})
export class AppModule { } //Root Module

//What do you mean by Angular Module ?
//it is like namespace  or package
//it consist of
//Basic building blocks:
// components, services, directives, pipes, decorators
// interface,classes
