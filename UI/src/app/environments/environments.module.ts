import { NgModule } from '@angular/core';
import { EnvironmentsComponent } from './environments/environments.component';
import { RouterModule, Routes } from '@angular/router';
import { GlobalModule } from '../global.module';

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
