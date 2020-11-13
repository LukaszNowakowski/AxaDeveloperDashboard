import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WorkItemsComponent } from './work-items/work-items.component';
import { GlobalModule } from '../global.module';
import { ProductionErrorsComponent } from './production-errors/production-errors.component';

const ROUTES: Routes = [
  { path: "workItems", component: WorkItemsComponent }
]

@NgModule({
  declarations: [
    WorkItemsComponent,
    ProductionErrorsComponent
  ],
  imports: [
    GlobalModule,
    RouterModule.forRoot(ROUTES)
  ]
})
export class WorkItemsModule { }
