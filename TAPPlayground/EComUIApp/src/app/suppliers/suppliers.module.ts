import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { GetsupplierComponent } from './getsupplier/getsupplier.component';
import { DetailsComponent } from './details/details.component';
import { SearchComponent } from './search/search.component';
import { InsertComponent } from './insert/insert.component';
import { UpdateComponent } from './update/update.component';
import { FormsModule } from '@angular/forms';
import { RoutingComponent } from './routing/routing.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ProductssupplierComponent } from './productssupplier/productssupplier.component';


const routes: Routes = [
  {path:'suppliers',component:ListComponent},
  {path:'suppliers-search',component:SearchComponent},
  {path:'suppliers/:id',component:DetailsComponent},
  {path:'suppliers-insertsupplier',component:InsertComponent},
  {path:'suppliers-update',component:UpdateComponent},
  {path:'suppliers-update/:id',component:UpdateComponent},
  {path:'suppliers-productssupplier',component:ProductssupplierComponent},

]

@NgModule({
  declarations: [
    ListComponent,
    GetsupplierComponent,
    DetailsComponent,
    SearchComponent,
    InsertComponent,
    UpdateComponent,
    RoutingComponent,
    ProductssupplierComponent
  ],
  exports:[
   RoutingComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forChild(routes)

  ]
})
export class SuppliersModule { }
