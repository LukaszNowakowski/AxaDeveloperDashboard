import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WorkItemsService } from '../services/work-items.service';

@Component({
  selector: 'app-work-items-environment-errors',
  templateUrl: './environment-errors.component.html',
  styleUrls: ['./environment-errors.component.scss']
})
export class EnvironmentErrorsComponent implements OnInit {

  constructor(
    private workItemsService: WorkItemsService,
    private fb: FormBuilder) { }

  get ProductionErrorId(): AbstractControl {
    return this.form.get('productionErrorId');
  }
  @Input() public Title = '';

  @Input() public Label = '';

  @Input() public OpeningMessage = '';

  public form: FormGroup;

  public DisplayMessage = false;

  @Input() public LogUrlRetriever: (errorId: number) => Promise<string> = e => Promise.resolve('');

  ngOnInit(): void {
    this.form = this.fb.group({
      productionErrorId: ['', [Validators.required]]
    });
  }

  public OpenError(): void {
    if (!this.form.valid) {
      return;
    }

    const cast = parseInt(this.ProductionErrorId.value, 10);
    if (!!cast) {
      this.LogUrlRetriever(cast)
        .then(url => {
          if (!!url) {
            this.DisplayMessage = true;
            setTimeout(() => window.open(url), 800);
          }
          else {
            alert('Error occured');
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
