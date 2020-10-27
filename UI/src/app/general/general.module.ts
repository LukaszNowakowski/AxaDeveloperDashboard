import { NgModule } from '@angular/core';
import { StyleSwitcherComponent } from './style-switcher/style-switcher.component';
import { GlobalModule } from '../global.module';

@NgModule({
  declarations: [
    StyleSwitcherComponent
  ],
  imports: [
    GlobalModule
  ],
  exports: [
    StyleSwitcherComponent
  ]
})
export class GeneralModule { }
