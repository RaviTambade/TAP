import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterContainerComponent } from './router-container/router-container.component';
import {RouterModule, Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { DashboardComponent } from './bi/dashboard/dashboard.component';
import { BarchartComponent } from './bi/barchart/barchart.component';
import { PieChartComponent } from './bi/pie-chart/pie-chart.component';
import { ProtectedComponent } from './protected/protected.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { AuthService } from './authservice';
import { LoggedInGuard } from './loggedinguardservice';
import { ProductListComponent } from './productCatalog/product-list/product-list.component';
import { ProductCreateComponent } from './productCatalog/product-create/product-create.component';
import { ProductDetailComponent } from '../spa/productCatalog/product-detail/product-detail.component';
import { ProductUpdateComponent } from './productCatalog/product-update/product-update.component';
import { ProductDeleteComponent } from './productCatalog/product-delete/product-delete.component';
import { ServicesComponent } from './services/services.component';
import { ProductService } from './product.service';


export const childRoutes:Routes=[

    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
    { path: 'bar', component: BarchartComponent },
    { path: 'pie', component: PieChartComponent},
];

const routes: Routes=
  [   {path:'', redirectTo:'home',pathMatch:"full"},
      { path: 'home', component: HomeComponent },
      { path: 'services', component: ServicesComponent },
      { path: 'about', component: AboutComponent,canActivate: [LoggedInGuard] },
      { path:'contact', component: ContactComponent},
      { path:'dashboard', component: DashboardComponent,children:childRoutes},
      { path: 'protected',component: ProtectedComponent,canActivate: [LoggedInGuard]}, //secure Routing
  
      {path: 'lists', component: ProductListComponent},
      {path: 'create', component: ProductCreateComponent},
      {path: 'lists/:id', component: ProductDetailComponent},

      {path: 'details/:id', component: ProductDetailComponent},///Paramterized Routing
      {path: 'update/:id', component: ProductUpdateComponent},
      {path: 'delete/:id', component: ProductDeleteComponent}
    ];


@NgModule({
  declarations: [RouterContainerComponent,
                 HomeComponent,
                 AboutComponent,
                 ContactComponent,
                 DashboardComponent,
                 BarchartComponent,
                 PieChartComponent,
                 ProtectedComponent,
                 SignInComponent,
                
                 ProductListComponent,
                 ProductDetailComponent,
                 ProductCreateComponent,
                 ProductDeleteComponent,
                 ProductUpdateComponent,
              
                ],
  exports:[RouterContainerComponent ],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  providers:[ProductService,AuthService,LoggedInGuard]
})
export class SPAModule { }
