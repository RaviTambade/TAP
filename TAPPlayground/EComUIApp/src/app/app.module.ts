import { DatePipe } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
<<<<<<< HEAD
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HRModuleModule } from './hrmodule/hrmodule.module';
=======
import { HttpClientModule} from '@angular/common/http';
import { TransactionModule } from './transaction/transaction.module';
import { AccountModule } from './account/account.module';
import { RouterModule, Routes } from '@angular/router';
>>>>>>> 351c287d7c3d43f0ef316585f784a62a731b5790
import { MembershipModule } from './membership/membership.module';
import { SuppliersModule } from './suppliers/suppliers.module';
import { DatePipe } from '@angular/common';
import { CustomerModule } from './customer/customer.module';
import { ProductsModule } from './product/products.module';
import { AppComponent } from './app.component';
import { ShipperModule } from './shipper/shipper.module';

//metadata
//decorator

<<<<<<< HEAD
const routes : Routes = [
=======
const routes: Routes = [
>>>>>>> 351c287d7c3d43f0ef316585f784a62a731b5790

]
@NgModule({
  declarations: [
  AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
<<<<<<< HEAD
    MembershipModule,
    HRModuleModule,
    HttpClientModule,
    DatePipe,
    RouterModule.forChild(routes),
  ],
  providers: [
    DatePipe
  ],
=======
    HttpClientModule,
    DatePipe,
    TransactionModule,
    AccountModule, 
    MembershipModule,
    ShipperModule,
    SuppliersModule,
    CustomerModule,
    ProductsModule,
    RouterModule.forRoot(routes),
    DatePipe
  ],
  providers: [DatePipe],
>>>>>>> 351c287d7c3d43f0ef316585f784a62a731b5790
  bootstrap: [AppComponent] //Root Component
})
export class AppModule { } //Root Module

//What do you mean by Angular Module ?
//it is like namespace  or package
//it consist of
//Basic building blocks:
// components, services, directives, pipes, decorators
// interface,classes
