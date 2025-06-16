import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookingPersonalElementComponent } from './booking-personal-element/booking-personal-element.component';
import { ApiService } from '../../../shared/services/api.service';
import { Title } from '@angular/platform-browser';
import { CoworkingWithRoomsResponseInterface } from './interfaces/coworking-with-rooms-response.interface';
import { Observable } from 'rxjs';
import { RouterLink } from '@angular/router';
import { GroqAssistantComponent } from '../../../shared/components/groq-assistant/groq-assistant.component';

@Component({
  selector: 'app-booking-personal-list',
  imports: [
    CommonModule,
    BookingPersonalElementComponent,
    RouterLink,
    GroqAssistantComponent,
  ],
  templateUrl: './booking-personal-list.component.html',
  styleUrl: './booking-personal-list.component.css',
})
export class BookingPersonalListComponent {
  private readonly userId: string = localStorage.getItem('uniqueId')!;
  pageData$?: Observable<CoworkingWithRoomsResponseInterface[]>;

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
    })}`,
  ];

  constructor(private titleService: Title, private apiService: ApiService) {
    this.pageData$ = apiService.get<CoworkingWithRoomsResponseInterface[]>(
      this.endpoint,
      this.userId
    );
  }
}
