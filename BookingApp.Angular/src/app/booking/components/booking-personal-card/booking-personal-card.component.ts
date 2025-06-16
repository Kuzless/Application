import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BookingInfoInterface } from '../../interfaces/booking-info.interface';
import { FormatImgPipe } from '../../pipes/format-img.pipe';
import { LowerCasePipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { DatePipe } from '@angular/common';
import { MultipleToSinglePipe } from '../../pipes/multiple-to-single.pipe';
import { ConfirmComponent } from './confirm/confirm.component';

@Component({
  selector: 'app-booking-personal-card',
  imports: [
    FormatImgPipe,
    LowerCasePipe,
    RouterLink,
    DatePipe,
    CommonModule,
    MultipleToSinglePipe,
    ConfirmComponent,
  ],
  templateUrl: './booking-personal-card.component.html',
  styleUrl: './booking-personal-card.component.css',
})
export class BookingPersonalCardComponent {
  @Input() booking?: BookingInfoInterface;
  @Output() delete = new EventEmitter<number>();

  readonly iconsUrl: string = 'booking/booking-element/icons/';
  readonly imagesUrl: string = 'booking/booking-element/images/';
  readonly iconsFormat: string = '.svg';
  readonly imagesFormat: string = '.png';

  readonly imageName: string = '1';
  readonly editIconName: string = 'edit';
  readonly deleteIconName: string = 'delete';
  readonly calendarIconName: string = 'calendar';
  readonly clockIconName: string = 'clock';

  private readonly endpoint: string = 'Booking';

  showWarning: boolean = false;

  get editBookingRoute() {
    return `../${this.booking?.room.coworkingId}/edit/${this.booking?.booking.id}`;
  }

  get startDateTime() {
    return `${this.booking?.booking.startDate}T${this.booking?.booking.startTime}`;
  }

  get endDateTime() {
    return `${this.booking?.booking.endDate}T${this.booking?.booking.endTime}`;
  }

  openWarning() {
    this.showWarning = true;
  }

  closeWarning() {
    this.showWarning = false;
  }

  deleteBooking() {
    this.delete.emit(this.booking!.booking.id);
    this.showWarning = false;
  }
}
