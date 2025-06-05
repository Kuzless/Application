import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  title = 'BookingApp.Angular';

  ngOnInit(): void {
    if (!localStorage.getItem('uniqueId')) {
      localStorage.setItem('uniqueId', uuidv4());
    }
  }
}
