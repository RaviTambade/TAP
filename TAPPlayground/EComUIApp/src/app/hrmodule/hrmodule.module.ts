import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { ListComponent } from './list/list.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { InsertComponent } from './insert/insert.component';
import { UpdateComponent } from './update/update.component';
import { SearchComponent } from './search/search.component';
import { GetbyidComponent } from './getbyid/getbyid.component';
import { DetailsComponent } from './details/details.component';
import { EmployeeRoutingComponent } from './employee-routing/employee-routing.component';
import { RouterModule, Routes } from '@angular/router';




export const employeeRoutes:Routes =[
  {path:'Emplist',component:ListComponent},
  {path:'Empgetbyid',component:SearchComponent},
  {path:'Emp-details/:id',component:DetailsComponent},
  {path:'Empinsert',component:InsertComponent},
  {path:'Empupdate',component:UpdateComponent},
  {path:'Emp-update/:id',component:UpdateComponent},
]

@NgModule({
  declarations: [
    ListComponent,
    InsertComponent,
    UpdateComponent,
    SearchComponent,
    GetbyidComponent,
    DetailsComponent,
    EmployeeRoutingComponent,
   
  ],
  exports:[
    ListComponent,
    InsertComponent,
    UpdateComponent,
    SearchComponent,
    GetbyidComponent,
    DetailsComponent,
    SearchComponent,
    EmployeeRoutingComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    DatePipe,
    RouterModule.forChild(employeeRoutes)
  ]
})
export class HRModuleModule {
  insert: any;
}
