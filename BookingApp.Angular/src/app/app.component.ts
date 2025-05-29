import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BookingElementComponent } from './booking/components/booking-element/booking-element.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, BookingElementComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'BookingApp.Angular';
}
