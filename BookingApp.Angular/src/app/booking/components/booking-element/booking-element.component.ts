import { Component, OnInit } from '@angular/core';
import { BookingElementService } from './services/booking-element.service';

@Component({
  selector: 'app-booking-element',
  imports: [],
  templateUrl: './booking-element.component.html',
  styleUrl: './booking-element.component.css',
})
export class BookingElementComponent implements OnInit {
  bookingService!: BookingElementService;

  constructor(bookingService: BookingElementService) {
    this.bookingService = bookingService;
  }
  ngOnInit(): void {
    console.log('Hello. Init triggered');
    this.bookingService.test();
  }
}
