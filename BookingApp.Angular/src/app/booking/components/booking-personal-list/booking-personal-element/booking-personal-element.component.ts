import { Component, Input } from '@angular/core';
import { UserBookingInfoResponseInterface } from '../interfaces/user-booking-info-response.interface';
import { FormatImgPipe } from '../../../shared/pipes/format-img.pipe';
import { LowerCasePipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { DatePipe } from '@angular/common';
import { MultipleToSinglePipe } from './pipes/multiple-to-single.pipe';
import { BookingApiService } from '../../../shared/services/booking-api.service';

@Component({
  selector: 'app-booking-personal-element',
  imports: [
    FormatImgPipe,
    LowerCasePipe,
    RouterLink,
    DatePipe,
    CommonModule,
    MultipleToSinglePipe,
  ],
  templateUrl: './booking-personal-element.component.html',
  styleUrl: './booking-personal-element.component.css',
})
export class BookingPersonalElementComponent {
  @Input() booking?: UserBookingInfoResponseInterface;

  private readonly endpoint: string = 'Booking';

  readonly iconsUrl: string = 'booking/booking-element/icons/';
  readonly imagesUrl: string = 'booking/booking-element/images/';
  readonly iconsFormat: string = '.svg';
  readonly imagesFormat: string = '.png';

  readonly imageName: string = '1';
  readonly editIconName: string = 'edit';
  readonly deleteIconName: string = 'delete';
  readonly calendarIconName: string = 'calendar';
  readonly clockIconName: string = 'clock';

  constructor(private apiService: BookingApiService) {}

  get editBookingRoute() {
    return `../edit/${this.booking?.booking.id}`;
  }

  get startDateTime() {
    return `${this.booking?.booking.startDate}T${this.booking?.booking.startTime}`;
  }

  get endDateTime() {
    return `${this.booking?.booking.endDate}T${this.booking?.booking.endTime}`;
  }

  deleteBooking() {
    this.apiService
      .delete(this.endpoint, this.booking?.booking.id!)
      .subscribe((response) => {
        console.log(response);
      });
  }
}
