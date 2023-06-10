import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InsertComponent } from './insert/insert.component';

import { RadioComponent } from './radio/radio.component';
import { CheckBoxComponent } from './check-box/check-box.component';
import { FileUploadComponent } from './file-upload/file-upload.component';
import { MutipleSelectListBoxComponent } from './mutiple-select-list-box/mutiple-select-list-box.component';
import { TflGridComponent } from './tfl-grid/tfl-grid.component';
import { PaggingComponent } from './pagging/pagging.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductService } from '../HTTP/producthubservice';
import { SortedListComponent } from './sorted-list/sorted-list.component';
import { AppService } from './aap.service';
import { NestedDropdownComponent } from './nested-dropdown/nested-dropdown.component';
import { CustomerlistDetailsComponent } from './customerlist-details/customerlist-details.component';
import { CustomerService } from './customer.service';
import { HoverableComponent } from './hoverable/hoverable.component';



@NgModule({
  declarations: [
    InsertComponent,
    RadioComponent,
    CheckBoxComponent,
    FileUploadComponent,
    MutipleSelectListBoxComponent,
    TflGridComponent,
    PaggingComponent,
    SortedListComponent,
    NestedDropdownComponent,
    CustomerlistDetailsComponent,
    HoverableComponent
  ],
  exports:[
    InsertComponent,
    RadioComponent,
    CheckBoxComponent,
    FileUploadComponent,
    MutipleSelectListBoxComponent,
    TflGridComponent,
    PaggingComponent,
    SortedListComponent,
    NestedDropdownComponent,
    CustomerlistDetailsComponent,
    HoverableComponent
  ],
providers:[ProductService,AppService,CustomerService],

  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class ReusableModule { }
