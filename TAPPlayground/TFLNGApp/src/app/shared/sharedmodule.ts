import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { BrandingComponent } from "./styleclass-directive/styleclass-directive.component";
import { InbuiltPipeComponent } from "./inbuilt-pipe/inbuilt-pipe.component";
import { JsonPipeComponent } from "./inbuilt-pipe/jsonpipe";
import { NumberPipeComponent } from "./inbuilt-pipe/decimalpipe";
import { ConditionalComponent } from "./conditional/conditional.component";
 
@NgModule({
    declarations: [
        BrandingComponent,
        InbuiltPipeComponent,
        JsonPipeComponent,
        NumberPipeComponent,
        ConditionalComponent,

    ],
    exports: [
        BrandingComponent,
        InbuiltPipeComponent,
        JsonPipeComponent,
        NumberPipeComponent,
        ConditionalComponent,

 
    
    ],
    imports:[
        BrowserModule
    ],

    providers:[ ],
})
export class SharedModule{}