import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';
import { ProducthubService } from '../producthub.service';
import { HttpClientModule } from '@angular/common/http';
import { CounterComponent } from './counter/counter.component';
import { FormsModule } from '@angular/forms';




@NgModule({
  declarations: [
    ListComponent,
    DetailsComponent,
    CounterComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule
  ],
  exports:[
    ListComponent,
    DetailsComponent
  ],
  providers:[
    ProducthubService
  ]
})
export class CatalogModule { }
