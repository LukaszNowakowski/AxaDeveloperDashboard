import { APP_INITIALIZER, NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { GlobalModule } from './global.module';

import { GeneralModule } from './general/general.module';
import { HomeModule } from './home/home.module';
import { EnvironmentsModule } from './environments/environments.module';
import { StyleTogglerService } from './services/style-toggler.service';

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
    AppRoutingModule,
    GeneralModule
  ],
  providers: [
    StyleTogglerService,
    { provide: APP_INITIALIZER, useFactory: themeFactory, deps: [StyleTogglerService], multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
