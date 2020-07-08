import { Component, OnInit } from '@angular/core';
import * as model from './home.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public EnvironmentsVisible: boolean = false;

  public Environments: model.EnvironmentInformation[] = [];

  constructor() { }

  ngOnInit(): void {
    var result: model.EnvironmentInformation[] = [
      { name: 'CI', buildName: 'INT.Par.Leonardo.2020.07.08.15', testResults: {ran: 2673, passed: 1954, failed: 719, passRate: 73.1 } },
      { name: 'CI2', buildName: 'INT.Par.Leonardo.2020.07.08.15', testResults: {ran: 2673, passed: 1954, failed: 719, passRate: 73.1 } },
      { name: 'CI3', buildName: 'INT.Par.Leonardo.2020.07.08.15', testResults: {ran: 2673, passed: 1954, failed: 719, passRate: 73.1 } },
      { name: 'DIT01', buildName: 'INT.Par.Leonardo.2020.07.08.15', testResults: {ran: 2673, passed: 1954, failed: 719, passRate: 73.1 } },
      { name: 'DIT02', buildName: 'INT.Par.Leonardo.2020.07.08.15', testResults: {ran: 2673, passed: 1954, failed: 719, passRate: 73.1 } },
      { name: 'DIT03', buildName: 'INT.Par.Leonardo.2020.07.08.15', testResults: {ran: 2673, passed: 1954, failed: 719, passRate: 73.1 } },
    ];
    this.Environments = result;
  }
}
