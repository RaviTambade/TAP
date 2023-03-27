import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { GetsupplierComponent } from './getsupplier/getsupplier.component';
import { DetailsComponent } from './details/details.component';
import { SearchComponent } from './search/search.component';
import { InsertComponent } from './insert/insert.component';
import { UpdateComponent } from './update/update.component';
import { DeleteComponent } from './delete/delete.component';
import { FormsModule } from '@angular/forms';
import { RoutingComponent } from './routing/routing.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';


const routes: Routes = [
  {path:'suppliers',component:ListComponent},
  {path:'search',component:SearchComponent},
  {path:'insert',component:InsertComponent},
  {path:'update',component:UpdateComponent},
  {path:'delete',component:DeleteComponent},
]

@NgModule({
  declarations: [
    ListComponent,
    GetsupplierComponent,
    DetailsComponent,
    SearchComponent,
    InsertComponent,
    UpdateComponent,
    DeleteComponent,
    RoutingComponent
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
