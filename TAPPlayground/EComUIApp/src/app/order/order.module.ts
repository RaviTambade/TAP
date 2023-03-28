import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'
import { OrderhubService } from './orderhub.service';
import { DetailsComponent } from './details/details.component';
import { InsertComponent } from './insert/insert.component';
import { UpdateComponent } from './update/update.component';
import { GetorderComponent } from './getorder/getorder.component';
import { RouterModule,Routes } from '@angular/router';
import { RoutingComponent } from './routing/routing.component';
import { SearchComponent } from './search/search.component';

const routes: Routes = [
  {path:'app-list',component:ListComponent},
  {path:'app-Search',component:SearchComponent},
  {path:'app-insert',component:InsertComponent},
  {path:'order-update',component:UpdateComponent}

]


@NgModule({
  declarations: [
    ListComponent,
    DetailsComponent,
    InsertComponent,
    GetorderComponent,
    RoutingComponent,
    SearchComponent,
    UpdateComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    ListComponent,
    DetailsComponent,
    InsertComponent,
    UpdateComponent,
    GetorderComponent,
    SearchComponent,
    RoutingComponent,
  ],
  providers: [
    OrderhubService
  ]
})
export class OrderModule { }
