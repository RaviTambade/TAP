import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { SellingflowersPipe } from "./sellingflowerpipe";
import { HiddenDirective } from "./customdirectivehidden";
import { IfDirective } from "./customdirectiveif";
import { UnderlineDirective } from "./customdirectiveunderline";
 
@NgModule({
    declarations: [ 
                    SellingflowersPipe,
                    HiddenDirective,
                    IfDirective,
                    UnderlineDirective
                ],
    exports: [      SellingflowersPipe,
                    HiddenDirective,
                    IfDirective,
                    UnderlineDirective   
             ],
    imports:[ BrowserModule],

    providers:[ ],
})
export class Customodule{}