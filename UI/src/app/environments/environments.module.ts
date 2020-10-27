import { NgModule } from '@angular/core';
import { EnvironmentsComponent } from './environments/environments.component';
import { GlobalModule } from '../global.module';
import { RouterModule, Routes } from '@angular/router';

const ROUTES: Routes = [
  { path: "environments", component: EnvironmentsComponent }
]

@NgModule({
  declarations: [
    EnvironmentsComponent
  ],
  imports: [
    GlobalModule,
    RouterModule.forRoot(ROUTES)
  ]
})
export class EnvironmentsModule { }
