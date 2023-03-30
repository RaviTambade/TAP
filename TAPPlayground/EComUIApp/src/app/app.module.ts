
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HRModuleModule } from './hrmodule/hrmodule.module';
import { HttpClientModule} from '@angular/common/http';
import { TransactionModule } from './transaction/transaction.module';
import { AccountModule } from './account/account.module';
import { RouterModule, Routes } from '@angular/router';
import { MembershipModule } from './membership/membership.module';
import { SuppliersModule } from './suppliers/suppliers.module';
import { CustomerModule } from './customer/customer.module';
import { PaymentModule } from './payment/payment.module';
import { ProductsModule } from './product/products.module';
import { ShipperModule } from './shipper/shipper.module';
import { AppComponent } from './app.component';
import { DatePipe } from '@angular/common';


//metadata
//decorator

const routes: Routes = [

]
@NgModule({
    declarations: [
        AppComponent
    ],
    providers: [DatePipe],
    bootstrap: [AppComponent] //Root Component
    ,
    imports: [
        BrowserModule,
        FormsModule,
        MembershipModule,
        HRModuleModule,
        HttpClientModule,
        DatePipe,
        TransactionModule,
        AccountModule,
        ShipperModule,
        SuppliersModule,
        CustomerModule,
        PaymentModule,
        RouterModule.forRoot(routes),
        ProductsModule
    ]
})
export class AppModule { } //Root Module

//What do you mean by Angular Module ?
//it is like namespace  or package
//it consist of
//Basic building blocks:
// components, services, directives, pipes, decorators
// interface,classes
