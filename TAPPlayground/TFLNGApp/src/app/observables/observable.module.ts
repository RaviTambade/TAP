import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule} from "@angular/forms";

import { MessageService } from "./messageservice";
import { AccountService } from "./accountservice";

import { SimpleObservableComponent } from "./simple-observable/simple-observable.component";
import { AccountComponent } from './account/account.component';
import { BankComponent } from './bank/bank.component';
import { MasterComponent } from './communication/master/master.component';
import { DetailComponent } from './communication/detail/detail.component';
import { Consumer1Component } from './communication/consumer1/consumer1.component';
import { Consumer2Component } from './communication/consumer2/consumer2.component';
import { SubjectiveComponent } from './subjective/subjective.component';

@NgModule({
    declarations: [ SimpleObservableComponent,
                    MasterComponent,
                    DetailComponent ,
                    MasterComponent,
                    DetailComponent,
                    Consumer1Component,
                    Consumer2Component ,
                    AccountComponent,  
                    BankComponent, SubjectiveComponent,
    ],
    exports: [      SimpleObservableComponent,
                    MasterComponent,
                    DetailComponent,
                    Consumer1Component,
                    Consumer2Component,
                    BankComponent,
                    SubjectiveComponent
                    
    ],
    imports:[
                    BrowserModule,
                    FormsModule
    ],

    providers:[MessageService,AccountService ],
})
export class ObservableModule{}