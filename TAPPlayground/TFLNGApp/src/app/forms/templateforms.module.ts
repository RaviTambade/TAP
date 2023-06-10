import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { LoginService } from "./loginservice";
import { SignInComponent } from "./sign-in/sign-in.component";
import { RegisterComponent } from "./register/register.component";
import { ChangePasswordComponent } from "./change-password/change-password.component";
@NgModule({
    declarations: [
        SignInComponent,
        RegisterComponent,
        ChangePasswordComponent         
    ],
    exports: [SignInComponent,
              RegisterComponent,
              ChangePasswordComponent],
    imports:[BrowserModule,
             FormsModule],
    providers:[LoginService ],
})
export class TemplateFormsModule{}