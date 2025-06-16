import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookingPersonalCardComponent } from '../booking-personal-card/booking-personal-card.component';
import { RouterLink } from '@angular/router';
import { GroqAssistantComponent } from '../../../shared/components/groq-assistant/groq-assistant.component';
import { Store } from '@ngrx/store';
import { selectCoworkings } from './state/personal-bookings.selectors';
import {
  loadCoworkings,
  deleteBooking,
} from './state/personal-bookings.actions';
import { Observable } from 'rxjs';
import { BookingCardDataInterface } from '../../interfaces/booking-page/booking-card-data.interface';

@Component({
  selector: 'app-booking-personal-page',
  imports: [
    CommonModule,
    BookingPersonalCardComponent,
    RouterLink,
    GroqAssistantComponent,
  ],
  templateUrl: './booking-personal-page.component.html',
  styleUrl: './booking-personal-page.component.css',
})
export class BookingPersonalPageComponent {
  private readonly store = inject(Store);
  pageData$ = this.store.select(selectCoworkings);

  private getEndpoint: string = 'Booking/user';
  private deleteEndpoint: string = 'Booking';
  readonly groqEndpoint = 'Groq/booking';

  readonly groqTemplate = [
    'How many bookings do i have?',
    'What was booked last week?',
    `Do i have something on ${new Date(
      Date.now() + 24 * 60 * 60 * 1000
    ).toLocaleDateString(undefined, {
      month: 'long',
      day: 'numeric',
    })}?`,
  ];

  constructor() {
    this.store.dispatch(
      loadCoworkings({
        endpoint: this.getEndpoint,
        userId: localStorage.getItem('uniqueId')!,
      })
    );
  }

  onDelete(bookingId: number) {
    this.store.dispatch(
      deleteBooking({ endpoint: this.deleteEndpoint, id: bookingId })
    );
  }
}
