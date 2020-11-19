import { APP_INITIALIZER, NgModule } from '@angular/core';
import { EnvironmentsComponent } from './environments/environments.component';
import { GlobalModule } from '../global.module';
import { RouterModule, Routes } from '@angular/router';

import { HttpEnvironmentsService } from './services/http-environments.service';
import { AuthGuard } from '../guards/auth-guard';
import { EnvironmentsState } from './redux/state';

const ROUTES: Routes = [
  { path: 'environments', component: EnvironmentsComponent, canActivate: [AuthGuard] },
];

@NgModule({
  declarations: [
    EnvironmentsComponent
  ],
  imports: [
    GlobalModule,
    RouterModule.forRoot(ROUTES)
  ],
  providers: [
    HttpEnvironmentsService,
    EnvironmentsState
  ]
})
export class EnvironmentsModule { }
