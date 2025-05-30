import { Component, OnInit } from '@angular/core';
import { BookingApiService } from '../../services/booking-api.service';
import { RoomTypeInfoInterface } from '../../interfaces/booking-main/room-type-info.interface';
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
  pageData$?: Observable<RoomTypeInfoInterface[]>;

  constructor(apiService: BookingApiService) {
    this.apiService = apiService;
  }

  ngOnInit(): void {
    this.pageData$ = this.apiService.getByEmail<RoomTypeInfoInterface[]>(
      'Booking',
      'qwe'
    );
  }
}
