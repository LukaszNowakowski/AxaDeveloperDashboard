import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BrowserPersistenceService {
  private storage = localStorage;

  public GetValue(key: string): string {
    return this.storage.getItem(key);
  }

  public SetValue(key: string, value: string): void {
    this.storage.setItem(key, value);
  }
}
