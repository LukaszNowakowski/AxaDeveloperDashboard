import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WorkItemsService } from '../services/work-items.service';

@Component({
  selector: 'workItems-environment-errors',
  templateUrl: './environment-errors.component.html',
  styleUrls: ['./environment-errors.component.scss']
})
export class EnvironmentErrorsComponent implements OnInit {
  @Input() public Title: string = "";

  @Input() public Label: string = "";

  @Input() public OpeningMessage: string = "";

  @Input() public LogUrlRetriever: (errorId: number) => Promise<string> = e => Promise.resolve("");

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
      this.LogUrlRetriever(cast)
        .then(url => {
          if (!!url) {
            this.DisplayMessage = true;
            setTimeout(() => window.open(url), 800);
          }
          else {
            alert("Error occured");
          }
        })
        .finally(() => {
          setTimeout(() => {
            this.DisplayMessage = false;
            this.form.reset();
            this.ProductionErrorId.setErrors(null);
          }, 2000);
        });
    }
  }
}
