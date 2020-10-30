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
import { StyleTogglerService } from './services/style-toggler.service';
import { ApplicationInitializationModule } from './application-initialization/application-initialization.module';
import { ServicesState } from './services/redux/state';

export function themeFactory(themeService: StyleTogglerService) {
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
    AppRoutingModule,
    GeneralModule,
    ApplicationInitializationModule,
    NgxsModule.forRoot([ServicesState], {}),
    NgxsReduxDevtoolsPluginModule.forRoot()
  ],
  providers: [
    StyleTogglerService,
    { provide: APP_INITIALIZER, useFactory: themeFactory, deps: [StyleTogglerService], multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
