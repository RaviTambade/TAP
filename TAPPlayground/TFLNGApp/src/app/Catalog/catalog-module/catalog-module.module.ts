import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DetailComponent } from '../detail/detail.component';
import {FormsModule} from '@angular/forms';
import { ListComponent } from '../list/list.component';
import { DeleteComponent } from '../delete/delete.component';
import { UpdateComponent } from '../update/update.component';
import { ListService } from '../listservice';
import { CounterComponent } from '../counter/counter.component';
import {SellinglistComponent} from "../sellinglist/sellinglist.component";
import { Customodule } from '../../custom/customodule';


//Decorator: meta data , extra information for framework to understand
@NgModule({
  imports: [    //imports only modules:  which are inbuilt or custom modules
    CommonModule,
    FormsModule,
    Customodule
  ],
  declarations: [DetailComponent,ListComponent,
                 UpdateComponent,DeleteComponent,
                 CounterComponent,SellinglistComponent
  ], // declare component, pipes, directives
  exports:[DetailComponent,ListComponent,
           UpdateComponent,DeleteComponent,SellinglistComponent],  //publish component, pipes, directives
 
         // publish services
  providers:[ListService]  
})
export class CatalogModuleModule { }
