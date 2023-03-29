import { DatePipe } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HRModuleModule } from './hrmodule/hrmodule.module';
import { MembershipModule } from './membership/membership.module';

//metadata
//decorator

const routes : Routes = [

]
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    MembershipModule,
    HRModuleModule,
    HttpClientModule,
    DatePipe,
    RouterModule.forChild(routes),
  ],
  providers: [
    DatePipe
  ],
  bootstrap: [AppComponent] //Root Component
})
export class AppModule { } //Root Module

//What do you mean by Angular Module ?
//it is like namespace  or package
//it consist of
//Basic building blocks:
// components, services, directives, pipes, decorators
// interface,classes
