/*import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }*/
import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from './login/login.component';
import {AuthLayoutComponent} from './auth-layout/auth-layout.component';
import {RegisterComponent} from './register/register.component';

const routes: Routes = [
  {
    path: '', component: AuthLayoutComponent, children: [
      {path: '', redirectTo: 'login', pathMatch: 'full'},
      {path: 'login', component: LoginComponent},
      { path: 'register', component: RegisterComponent },

      //{path: 'logout', component: LogoutComponent},
      //{path: 'forget-password', component: ForgetPasswordComponent},
      //{path: 'two-factor', component: TwoFactorComponent},
      //{path: '', component: AdminErrorPageComponent}  // Default ruta koja vodi na public
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule{
}
