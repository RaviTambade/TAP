import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CatalogModuleModule } from './Catalog/catalog-module/catalog-module.module';
import { SharedModule } from './shared/sharedmodule';
import { MembershipModule } from './membership/membership.module';
//import { SPAModule } from './Routing/SPAModule';
import { GraphicsModule } from './graphics/graphics.module';
import { TemplateFormsModule } from './forms/templateforms.module';
import { ReusableModule } from './reusable/reusable.module';
import { ObservableModule } from './observables/observable.module';
import { SPAModule } from './spa/spa.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CatalogModuleModule,
    SharedModule,
    MembershipModule,
    GraphicsModule,
    TemplateFormsModule,
    ReusableModule,
    ObservableModule,
    SPAModule
   
  ],
  
  bootstrap: [AppComponent]
})

export class AppModule { }
