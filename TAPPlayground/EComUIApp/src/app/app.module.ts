
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HRModuleModule, employeeRoutes } from './hrmodule/hrmodule.module';
import { HttpClientModule} from '@angular/common/http';
import { TransactionModule, transacationRoutes } from './transaction/transaction.module';
import { AccountModule,accountRoutes } from './account/account.module';
import { RouterModule, Routes } from '@angular/router';
import { MembershipModule, membershipRoutes } from './membership/membership.module';
import { SuppliersModule,supplierRoutes } from './suppliers/suppliers.module';
import { CustomerModule ,customerRoutes} from './customer/customer.module';
import { PaymentModule, PaymentRoutes } from './payment/payment.module';
import { ProductsModule, productRoutes } from './product/products.module';
import { ShipperModule, shipperRoutes } from './shipper/shipper.module';
import { AppComponent } from './app.component';
import { DatePipe } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { ContactComponent } from './contact/contact.component';
import { OrderModule, orderRoutes } from './order/order.module';
import { RouteComponent } from './customer/route/route.component';
import { EmployeeRoutingComponent } from './hrmodule/employee-routing/employee-routing.component';
import { ProductRoutingComponent } from './product/product-routing/product-routing.component';
import { MembershipRoutingComponent } from './membership/membership-routing/membership-routing.component';

import { RoutingComponent } from './transaction/routing/routing.component';
import { SupplierRoutingComponent } from './suppliers/supplier-routing/supplier-routing.component';
import { ShipperroutingComponent } from './shipper/shipperrouting/shipperrouting.component';
import { AccountRoutingComponent } from './account/account-routing/account-routing.component';
import { CartModule } from './cart/cart.module';



//metadata
//decorator

const routes: Routes = [
  {path:'Home' , component:HomeComponent},
  {path:'Aboutus',component:AboutusComponent},
  {path:'Contact',component:ContactComponent},
  {path:'Catalog',component:ProductRoutingComponent,children:productRoutes},
  {path:'membership',component:MembershipRoutingComponent,children:membershipRoutes },
  //{path:'Cart',component:CartComponent},
  // {path:'Orders',component:OrdersComponent},
 {path:'Customer',component:RouteComponent,children:customerRoutes},
 {path:'supplier',component:SupplierRoutingComponent,children:supplierRoutes},
 {path:'Employee',component:EmployeeRoutingComponent,children:employeeRoutes},
 {path:'Shipper',component:ShipperroutingComponent,children:shipperRoutes},

 {path:'Payment',component:RoutingComponent,children:PaymentRoutes},
 {path:'Transaction',component:RoutingComponent,children:transacationRoutes},
{path:'Account',component:AccountRoutingComponent,children:accountRoutes},
]
@NgModule({
  declarations: [
  AppComponent,
  HomeComponent,
  AboutusComponent,
  ContactComponent,


  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    DatePipe,
    AccountModule, 
    MembershipModule,
    ShipperModule,
    SuppliersModule,
    CustomerModule,
    RouterModule.forRoot(routes),
    DatePipe,
    TransactionModule,
    ProductsModule,
    HRModuleModule,
    PaymentModule,
    OrderModule,
    CartModule

  
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
