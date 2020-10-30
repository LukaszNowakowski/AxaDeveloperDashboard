import { APP_INITIALIZER, NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ConfigurationService } from './services/configuration.service';

export function initApplication(configurationService: ConfigurationService) {
  console.log("initApplication started");
  return () => configurationService.Configure();
}

@NgModule({
  imports: [
    HttpClientModule
  ],
  providers: [
    ConfigurationService,
    { provide: APP_INITIALIZER, useFactory: initApplication, deps: [ConfigurationService], multi: true}
  ]
})
export class ApplicationInitializationModule { }
