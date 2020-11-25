import { APP_INITIALIZER, NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ConfigurationService } from './services/configuration.service';
import { SecurityService } from '../security/services/security.service';
import { EnvironmentsService } from '../environments/services/environments.service';

export function initApplication(
  configurationService: ConfigurationService,
  securityService: SecurityService,
  environmentsService: EnvironmentsService): () => Promise<void> {
  return () => configurationService.Configure()
    .then(() => {
      return securityService.Initialize()
        .then(security => {
          if (security) {
            return environmentsService.RefreshEnvironments();
          }

          return Promise.resolve({});
        });
    });
}

@NgModule({
  imports: [
    HttpClientModule
  ],
  providers: [
    ConfigurationService,
    {
      provide: APP_INITIALIZER,
      useFactory: initApplication,
      deps: [ConfigurationService, SecurityService, EnvironmentsService],
      multi: true
    }
  ]
})
export class ApplicationInitializationModule { }
