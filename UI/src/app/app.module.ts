import { APP_INITIALIZER, NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgxsModule } from '@ngxs/store';
import { NgxsReduxDevtoolsPluginModule } from '@ngxs/devtools-plugin';

import { GlobalModule } from './global.module';

import { GeneralModule } from './general/general.module';
import { HomeModule } from './home/home.module';
import { EnvironmentsModule } from './environments/environments.module';
import { WorkItemsModule } from './work-items/work-items.module';
import { SecurityModule } from './security/security.module';
import { StyleTogglerService } from './services/style-toggler.service';
import { ApplicationInitializationModule } from './application-initialization/application-initialization.module';
import { ServicesState } from './services/redux/state';
import { EnvironmentsState } from './environments/redux/state';
import { SecurityState } from './security/redux/state';

export function themeFactory(
  themeService: StyleTogglerService): () => void {
  return () => themeService.setThemeOnStart();
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    GlobalModule,
    HomeModule,
    EnvironmentsModule,
    WorkItemsModule,
    SecurityModule,
    AppRoutingModule,
    GeneralModule,
    ApplicationInitializationModule,
    NgxsModule.forRoot([ServicesState, EnvironmentsState, SecurityState], {}),
    NgxsReduxDevtoolsPluginModule.forRoot()
  ],
  providers: [
    StyleTogglerService,
    { provide: APP_INITIALIZER, useFactory: themeFactory, deps: [StyleTogglerService], multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
