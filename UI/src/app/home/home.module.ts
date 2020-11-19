import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { GlobalModule } from '../global.module';
import { AuthGuard } from '../guards/auth-guard';

const ROUTES: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
];

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    GlobalModule,
    RouterModule.forRoot(ROUTES),
  ]
})
export class HomeModule { }
