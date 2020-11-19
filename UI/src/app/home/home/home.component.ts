import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  public PrepareTitle(title: string): string {
    let result: string = title || '';
    if (result.length > 50) {
      result = result.substring(0, 50) + '...';
    }

    return result;
  }
}
