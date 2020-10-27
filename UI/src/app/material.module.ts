import { NgModule } from "@angular/core";

import { MatCardModule } from "@angular/material/card";
import { MatIconModule } from "@angular/material/icon";
import { MatSlideToggleModule } from "@angular/material/slide-toggle";
import { MatButtonModule } from '@angular/material/button';

@NgModule({
    exports: [
        MatCardModule,
        MatIconModule,
        MatSlideToggleModule,
        MatButtonModule
    ]
})
export class MaterialModule { }