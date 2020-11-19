import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WorkItemsComponent } from './work-items/work-items.component';
import { GlobalModule } from '../global.module';
import { EnvironmentErrorsComponent } from './environment-errors/environment-errors.component';
import { AuthGuard } from '../guards/auth-guard';

const ROUTES: Routes = [
  { path: 'workItems', component: WorkItemsComponent, canActivate: [AuthGuard] }
];

@NgModule({
  declarations: [
    WorkItemsComponent,
    EnvironmentErrorsComponent
  ],
  imports: [
    GlobalModule,
    RouterModule.forRoot(ROUTES)
  ]
})
export class WorkItemsModule { }
