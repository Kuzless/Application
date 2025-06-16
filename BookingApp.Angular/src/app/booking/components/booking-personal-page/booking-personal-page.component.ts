import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookingPersonalCardComponent } from '../booking-personal-card/booking-personal-card.component';
import { ApiService } from '../../../shared/services/api.service';
import { Title } from '@angular/platform-browser';
import { BookingPersonalCardDataInterface } from '../../interfaces/booking-personal-page/booking-personal-card-data.interface';
import { Observable } from 'rxjs';
import { RouterLink } from '@angular/router';
import { GroqAssistantComponent } from '../../../shared/components/groq-assistant/groq-assistant.component';

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
  private readonly userId: string = localStorage.getItem('uniqueId')!;
  pageData$?: Observable<BookingPersonalCardDataInterface[]>;

  private endpoint: string = 'Booking/user';
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

  constructor(private titleService: Title, private apiService: ApiService) {
    this.pageData$ = apiService.get<BookingPersonalCardDataInterface[]>(
      this.endpoint,
      this.userId
    );
  }
}
