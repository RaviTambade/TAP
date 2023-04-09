import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ListComponent } from './list/list.component';
import { UpdateComponent } from './update/update.component';
import { InsertComponent } from './insert/insert.component';
import { SearchProductComponent } from './search-product/search-product.component';
import { GetproductComponent } from './getproduct/getproduct.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ProductRoutingComponent } from './product-routing/product-routing.component';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './Auth/auth.guard';
import { HikepriceComponent } from './hikeprice/hikeprice.component';
// import { MatSelectModule } from '@angular/material/select';
// import { MatButtonModule } from '@angular/material/button';
// import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';

export const productRoutes:Routes =[
  {path:'products' , component:ListComponent},
  {path:'product-search',component:SearchProductComponent},
  {path:'product/:id',component:ProductDetailsComponent},
  {path:'product-insert',component:InsertComponent},
  {path:'product-update',component:UpdateComponent},
  {path:'product-update/:id',component:UpdateComponent},
  {path:'product-hikeprice',component:HikepriceComponent},
  {path:'product-hikeprice/:id',component:HikepriceComponent}
  
]

@NgModule({
  declarations: [
    ProductDetailsComponent,
    ListComponent,
    UpdateComponent,
    InsertComponent,
    SearchProductComponent,
    GetproductComponent,
    ProductRoutingComponent,
    HikepriceComponent,
    
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    // MatSelectModule,
    // MatButtonModule,
    // NgxMatSelectSearchModule
  ],
  exports:[
    ProductRoutingComponent
  ]
})
export class ProductsModule { }
