import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

export enum ThemeMode {
  DARK,
  LIGHT
}

@Injectable({
  providedIn: 'root'
})
export class StyleTogglerService {
  private readonly THEME_KEY = "THEME";
  private readonly DARK_THEME_VALUE = "DARK";
  private readonly LIGHT_THEME_VALUE = "LIGHT";
  private readonly DARK_THEME_CLASS_NAME = 'theme-dark';

  private storage: Storage;

  private darkThemeSelected: boolean = false;

  public theme$ = new BehaviorSubject<ThemeMode>(ThemeMode.LIGHT);

  constructor() {
    this.storage = localStorage;
  }
  
  public setThemeOnStart() {
    if (this.isDarkThemeSelected()) {
      this.setDarkTheme();
    }
    else {
      this.setLightTheme();
    }

    setTimeout(() => {
      document.body.classList.add('animate-colors-transition');
    }, 500);
  }

  public toggle() {
    if(this.darkThemeSelected) {
      this.setLightTheme();
    }
    else{
      this.setDarkTheme();
    }
  }

  public selectedTheme() : ThemeMode {
    return this.darkThemeSelected ? ThemeMode.DARK : ThemeMode.LIGHT;
  }

  private isDarkThemeSelected(): boolean {
    this.darkThemeSelected = this.storage.getItem(this.THEME_KEY) === this.DARK_THEME_VALUE;
    return this.darkThemeSelected;
  }

  private setLightTheme() {
    this.storage.setItem(this.THEME_KEY, this.LIGHT_THEME_VALUE);
    document.body.classList.remove(this.DARK_THEME_CLASS_NAME);
    this.darkThemeSelected = false;
    this.theme$.next(ThemeMode.LIGHT);
  }

  private setDarkTheme() {
    this.storage.setItem(this.THEME_KEY, this.DARK_THEME_VALUE);
    document.body.classList.add(this.DARK_THEME_CLASS_NAME);
    this.darkThemeSelected = true;
    this.theme$.next(ThemeMode.DARK);
  }
}
