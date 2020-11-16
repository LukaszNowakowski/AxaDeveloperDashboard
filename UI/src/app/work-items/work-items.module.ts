import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WorkItemsComponent } from './work-items/work-items.component';
import { GlobalModule } from '../global.module';
import { EnvironmentErrorsComponent } from './environment-errors/environment-errors.component';

const ROUTES: Routes = [
  { path: 'workItems', component: WorkItemsComponent }
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
