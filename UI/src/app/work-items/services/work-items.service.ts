import { Injectable } from '@angular/core';
import * as models from './work-items.models';
import { HttpWorkItemsService } from './http-work-items.service';

@Injectable({
  providedIn: 'root'
})
export class WorkItemsService {
  constructor(private httpService: HttpWorkItemsService) { }

  public CreateProductionLogUrl(request: models.CreateProductionLogUrlRequest): Promise<models.CreateProductionLogUrlResponse> {
    return this.httpService.FetchEnvironments(request.ErrorId)
      .then(result => {
        return { Success: true, Url: result };
      })
      .catch(error => {
        return { Success: false, Url: "", Error: error };
      });
  }
}
