import { Component, Input } from '@angular/core';
import { UserBookingInfoResponseInterface } from '../interfaces/user-booking-info-response.interface';
import { FormatImgPipe } from '../../../shared/pipes/format-img.pipe';
import { LowerCasePipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { DatePipe } from '@angular/common';
import { MultipleToSinglePipe } from './pipes/multiple-to-single.pipe';
import { ConfirmComponent } from '../components/confirm/confirm.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-booking-personal-element',
  imports: [
    FormatImgPipe,
    LowerCasePipe,
    RouterLink,
    DatePipe,
    CommonModule,
    MultipleToSinglePipe,
    ConfirmComponent,
  ],
  templateUrl: './booking-personal-element.component.html',
  styleUrl: './booking-personal-element.component.css',
})
export class BookingPersonalElementComponent {
  @Input() booking?: UserBookingInfoResponseInterface;

  readonly iconsUrl: string = 'booking/booking-element/icons/';
  readonly imagesUrl: string = 'booking/booking-element/images/';
  readonly iconsFormat: string = '.svg';
  readonly imagesFormat: string = '.png';

  readonly imageName: string = '1';
  readonly editIconName: string = 'edit';
  readonly deleteIconName: string = 'delete';
  readonly calendarIconName: string = 'calendar';
  readonly clockIconName: string = 'clock';

  showWarning: boolean = false;

  constructor(private router: Router) {}

  get editBookingRoute() {
    return `../edit/${this.booking?.booking.id}`;
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

  refreshPage() {
    this.showWarning = false;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate(['/booking/my']);
    });
  }
}
