import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateAccountComponent } from './create-account/create-account.component';
import { LoginComponent } from './login/login.component';
import { GlobalModule } from '../global.module';

const ROUTES: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'createAccount', component: CreateAccountComponent },
];

@NgModule({
  declarations: [
    CreateAccountComponent,
    LoginComponent
  ],
  imports: [
    GlobalModule,
    RouterModule.forRoot(ROUTES),
  ]
})
export class SecurityModule { }
