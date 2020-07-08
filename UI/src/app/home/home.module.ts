import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MaterialModule } from '../material.module';

const ROUTES: Routes = [
  { path: "home", component: HomeComponent },
];

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forRoot(ROUTES),
    MaterialModule
  ]
})
export class HomeModule { }
