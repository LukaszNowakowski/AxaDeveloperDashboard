import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WorkItemsService } from '../services/work-items.service';

@Component({
  selector: 'workItems-production-errors',
  templateUrl: './production-errors.component.html',
  styleUrls: ['./production-errors.component.scss']
})
export class ProductionErrorsComponent implements OnInit {
  public form: FormGroup;

  public DisplayMessage: boolean = false;

  constructor(
    private workItemsService: WorkItemsService,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.form = this.fb.group({
      productionErrorId: ["", [Validators.required]]
    });
  }

  get ProductionErrorId(): AbstractControl {
    return this.form.get("productionErrorId");
  }

  public OpenError() {
    if (!this.form.valid) {
      return;
    }

    let cast = parseInt(this.ProductionErrorId.value);
    if (!!cast) {
      this.workItemsService.CreateProductionLogUrl({ ErrorId: cast })
        .then(r => {
          if (r.Success) {
            this.DisplayMessage = true;
            setTimeout(() => window.open(r.Url), 800);
          }
          else {
            alert(r.Error);
          }
        })
        .finally(() => {
          setTimeout(() => {
            this.DisplayMessage = false;
            this.ProductionErrorId.setValue("");
          }, 2000);
        });
    }
  }
}
