import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './components/login/login.component';
import { LoginAdminComponent } from './components/login-admin/login-admin.component';
import { RegisterComponent } from './components/register/register.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { LogoutComponent } from './components/logout/logout.component';


@NgModule({
  declarations: [
    AuthComponent,
    LoginComponent,
    LoginAdminComponent,
    RegisterComponent,
    LogoutComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    FontAwesomeModule,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AuthModule { }