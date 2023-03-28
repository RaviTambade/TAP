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

export const routes:Routes =[
  {path:'products' , component:ListComponent},
  {path:'product/search',component:SearchProductComponent},
  {path:'product/:id',component:ProductDetailsComponent},
  {path:'product/insert',component:InsertComponent},
  {path:'product/update',component:UpdateComponent},
  {path:'product/update/:id',component:UpdateComponent},
]

@NgModule({
  declarations: [
    ProductDetailsComponent,
    ListComponent,
    UpdateComponent,
    InsertComponent,
    SearchProductComponent,
    GetproductComponent,
    ProductRoutingComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forChild(routes)
  ],
  exports:[
    ProductRoutingComponent
  ]
})
export class ProductsModule { }
