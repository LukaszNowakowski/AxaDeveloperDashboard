import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Dashboard';

  public SideBarVisible = true;

  public SwitchSideBarVisibility(): void {
    this.SideBarVisible = !this.SideBarVisible;
  }
}
