import { Injectable } from '@angular/core';
import { BookingApiService } from '../../../services/booking-api.service';
import { RoomTypeInfoWithUserBookedInterface } from '../../../interfaces/room-type-info-with-user-booked.interface';

@Injectable({
  providedIn: 'root',
})
export class BookingElementService {
  private apiService!: BookingApiService;

  constructor(apiService: BookingApiService) {
    this.apiService = apiService;
  }

  test() {
    this.apiService
      .getByEmail<RoomTypeInfoWithUserBookedInterface[]>('Booking', 'qwe')
      .subscribe((data) => {
        data.forEach((item, index) => {
          console.log(`Item ${index} - id: ${item.id}, type: ${item.type}`);
        });
      });
  }
}
