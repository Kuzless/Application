import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookingPersonalElementComponent } from './booking-personal-element/booking-personal-element.component';
import { BookingApiService } from '../../shared/services/booking-api.service';
import { Title } from '@angular/platform-browser';
import { UserBookingInfoResponseInterface } from './interfaces/user-booking-info-response.interface';
import { Observable } from 'rxjs';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-booking-personal-list',
  imports: [CommonModule, BookingPersonalElementComponent, RouterLink],
  templateUrl: './booking-personal-list.component.html',
  styleUrl: './booking-personal-list.component.css',
})
export class BookingPersonalListComponent {
  readonly title: string;
  private readonly userId: string = localStorage.getItem('uniqueId')!;
  pageData$?: Observable<UserBookingInfoResponseInterface[]>;

  private endpoint: string = 'Booking/user';

  constructor(
    private titleService: Title,
    private apiService: BookingApiService
  ) {
    this.title = titleService.getTitle();
    this.pageData$ = apiService.get<UserBookingInfoResponseInterface[]>(
      this.endpoint,
      this.userId
    );
  }
}
