import { NgModule } from "@angular/core";
import {RouterModule, Routes} from "@angular/router";

import { ContactComponent } from "./contact/contact.component";
import { HomeComponent } from "./home/home.component";
import { AboutusComponent } from "./aboutus/aboutus.component";
import { ProductsComponent } from "./products/products.component";
import {RouterContainerComponent} from "./router-container/router-container.component";
import {BarChartComponent } from "./bar-chart/bar-chart.component";
import {PieChartComponent} from "./pie-chart/pie-chart.component";
import { DashboardComponent} from "./dashboard/dashboard.component";
import { LineChartComponent } from "./line-chart/line-chart.component";
//import {AuthService} from "./AuthService";

export const  childRoutes: Routes = [
    { path: '', redirectTo:'dashboard', pathMatch: 'full'},
    { path: 'bar', component: BarChartComponent },
    { path: 'line', component: LineChartComponent},
    { path: 'pie', component: PieChartComponent},
  ];

export const routes: Routes = [
    {path: '', redirectTo: 'home', pathMatch: 'full' },
    {path: 'home', component: HomeComponent },
    {path: 'about', component:AboutusComponent },
    {path: 'contact',component: ContactComponent },
    {path: 'products', component:ProductsComponent },
    {path: 'dashboard', component: DashboardComponent,children:childRoutes},//Nested Routing
  //  { path: '**', component: PagenotfoundComponent },
  ];
  
@NgModule({
    declarations:[
        HomeComponent,
        ContactComponent, 
        AboutusComponent,
        ProductsComponent,
        DashboardComponent,
        PieChartComponent,
        BarChartComponent,
        RouterContainerComponent,
        //SignInComponent

    ],
    imports:[
        RouterModule.forRoot(routes)
    ],
  //  providers:[LoggedInGuard,AuthService],
    exports:[ RouterContainerComponent,]

})
export class SPAModule{ }