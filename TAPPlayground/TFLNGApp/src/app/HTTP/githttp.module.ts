import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { GithubAPIService } from "./githubapiservice";
import { GitHTTPComponent } from "./git-http/git-http.component";
import { ProductHttpCRUDComponent } from '../HTTP/product-http-crud/product-http-crud.component';
import { ProductHttpCRUDSVCComponent } from '../HTTP/product-http-crudsvc/product-http-crudsvc.component';

@NgModule({
    declarations: [GitHTTPComponent, ProductHttpCRUDComponent, ProductHttpCRUDSVCComponent],
    exports: [GitHTTPComponent,
              ProductHttpCRUDComponent,
              ProductHttpCRUDSVCComponent,
    ],
    imports:[
        BrowserModule,
        FormsModule,
        HttpClientModule
    ],
    providers:[GithubAPIService ],
})
export class GitHttpModule{}