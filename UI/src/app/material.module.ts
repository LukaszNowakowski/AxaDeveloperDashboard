import { NgModule } from "@angular/core";

import {
    MatCardModule,
} from "@angular/material/card";

import {
    MatIconModule
} from "@angular/material/icon";

import {
    MatSlideToggleModule
} from "@angular/material/slide-toggle";

@NgModule({
    exports: [
        MatCardModule,
        MatIconModule,
        MatSlideToggleModule
    ]
})
export class MaterialModule { }