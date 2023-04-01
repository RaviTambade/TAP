
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
import { CustomerModule ,customerRoutes} from './customer/customer.module';
import { PaymentModule } from './payment/payment.module';
import { ProductsModule, productRoutes } from './product/products.module';
import { ShipperModule } from './shipper/shipper.module';
import { AppComponent } from './app.component';
import { DatePipe } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { ContactComponent } from './contact/contact.component';

import { SearchProductComponent } from './product/search-product/search-product.component';
import { ProductDetailsComponent } from './product/product-details/product-details.component';
import { UpdateComponent } from './product/update/update.component';
import { ListComponent } from './product/list/list.component';
import { InsertComponent } from './product/insert/insert.component';
import { OrderModule } from './order/order.module';
import { CatalogComponent } from './product/catalog/catalog.component';
import { RouteComponent } from './customer/route/route.component';


//metadata
//decorator

const routes: Routes = [
  {path:'Home' , component:HomeComponent},
  {path:'Aboutus',component:AboutusComponent},
  {path:'Contact',component:ContactComponent},
  {path:'Catalog',component:CatalogComponent,children:productRoutes},
  //{path:'Cart',component:CartComponent},
  // {path:'Orders',component:OrdersComponent},
 {path:'Customer',component:RouteComponent,children:customerRoutes},
  

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
