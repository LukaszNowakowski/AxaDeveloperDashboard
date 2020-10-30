import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpWorkItemsService {
  constructor(private http: HttpClient) { }

  public FetchEnvironments(errorId: number): Promise<string> {
    let path = `http://localhost:6501/workItems/productionLogPath/${errorId}`;
    console.log(path);
    return this.http.get<string>(path, {})
      .toPromise();
  }
}
