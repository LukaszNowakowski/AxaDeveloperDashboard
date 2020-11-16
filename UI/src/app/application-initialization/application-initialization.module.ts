import { APP_INITIALIZER, NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ConfigurationService } from './services/configuration.service';
import { EnvironmentsService } from '../environments/services/environments.service';

export function initApplication(
  configurationService: ConfigurationService,
  environmentsService: EnvironmentsService): () => Promise<void> {
  return () => configurationService.Configure()
    .then(() => {
      return environmentsService.RefreshEnvironments();
    });
}

@NgModule({
  imports: [
    HttpClientModule
  ],
  providers: [
    ConfigurationService,
    { provide: APP_INITIALIZER, useFactory: initApplication, deps: [ConfigurationService, EnvironmentsService], multi: true}
  ]
})
export class ApplicationInitializationModule { }
