import { Component, OnInit } from '@angular/core';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';

import { StyleTogglerService, ThemeMode } from '../../services/style-toggler.service';

@Component({
  selector: 'general-style-switcher',
  templateUrl: './style-switcher.component.html',
  styleUrls: ['./style-switcher.component.scss']
})
export class StyleSwitcherComponent {
  public Theme = ThemeMode;

  constructor(private styleToggler: StyleTogglerService) {
  }

  public get SelectedTheme() : ThemeMode {
    return this.styleToggler.selectedTheme();
  }

  public StyleChanged(data: MatSlideToggleChange) {
    this.styleToggler.toggle();
  }
}
