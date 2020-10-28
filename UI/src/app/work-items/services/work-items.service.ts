import { Injectable } from '@angular/core';
import * as models from './work-items.models';

@Injectable({
  providedIn: 'root'
})
export class WorkItemsService {
  public CreateProductionLogUrl(request: models.CreateProductionLogUrlRequest): Promise<models.CreateProductionLogUrlResponse> {
    return new Promise<models.CreateProductionLogUrlResponse>((resolve, reject) => {
      if (!!request && !!request.ErrorId) {
        var url = `http://ext-prod2-darwin.globaldirect.intraxa/Tools/logs/logViewer/${request.ErrorId}`;
        resolve({ Success: true, Url: url, Error: "" });
      }
      else {
        reject("No error id");
      }
    });
  }
}
