import { Component, OnInit } from '@angular/core';
import { BookingApiService } from '../../services/booking-api.service';
import { RoomTypeInfoWithUserBookedInterface } from '../../interfaces/room-type-info-with-user-booked.interface';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { BookingElementComponent } from '../booking-element/booking-element.component';

@Component({
  selector: 'app-booking',
  imports: [CommonModule, BookingElementComponent],
  templateUrl: './booking.component.html',
  styleUrl: './booking.component.css',
})
export class BookingComponent implements OnInit {
  private apiService!: BookingApiService;
  pageData$?: Observable<RoomTypeInfoWithUserBookedInterface[]>;

  constructor(apiService: BookingApiService) {
    this.apiService = apiService;
  }

  ngOnInit(): void {
    this.pageData$ = this.apiService.getByEmail<
      RoomTypeInfoWithUserBookedInterface[]
    >('Booking', 'qwe');
  }
}
