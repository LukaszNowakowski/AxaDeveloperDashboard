import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Dashboard';

  public SideBarVisible: boolean = true;

  public SwitchSideBarVisibility() {
    this.SideBarVisible = !this.SideBarVisible;
  }
}
