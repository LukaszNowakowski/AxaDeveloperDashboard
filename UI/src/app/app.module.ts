import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './material.module';
import { FormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HomeModule } from './home/home.module';
import { StyleTogglerService } from './services/style-toggler.service';

import { GeneralModule } from './general/general.module';

export function themeFactory(themeService: StyleTogglerService) {
  return () => themeService.setThemeOnStart();
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HomeModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MaterialModule,
    GeneralModule
  ],
  providers: [
    StyleTogglerService,
    { provide: APP_INITIALIZER, useFactory: themeFactory, deps: [StyleTogglerService], multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
