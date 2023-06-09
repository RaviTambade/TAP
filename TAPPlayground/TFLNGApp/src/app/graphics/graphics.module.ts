import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RectComponent } from "./rect/rect.component";
import { LineComponent } from "./line/line.component";
import { EllipseComponent } from "./ellipse/ellipse.component";
import { SmileyComponent } from "./smiley/smiley.component";
import { GDIComponent } from './gdi/gdi.component';

@NgModule({
    declarations: [
        LineComponent,
        RectComponent,
        EllipseComponent,
        SmileyComponent,
        GDIComponent
    ],
    exports: [
        LineComponent,
        RectComponent,
        EllipseComponent,
        SmileyComponent,
        GDIComponent
    ],
    imports:[
        BrowserModule
    ],

    providers:[ ],
})
export class GraphicsModule{}