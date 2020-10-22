import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StyleSwitcherComponent } from './style-switcher/style-switcher.component';
import { MaterialModule } from '../material.module';

@NgModule({
  declarations: [
    StyleSwitcherComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    StyleSwitcherComponent
  ]
})
export class GeneralModule { }
