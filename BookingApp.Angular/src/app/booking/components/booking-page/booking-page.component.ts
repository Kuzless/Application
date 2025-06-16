import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../shared/services/api.service';
import { BookingCardDataInterface } from '../../interfaces/booking-page/booking-card-data.interface';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { BookingCardComponent } from '../booking-card/booking-card.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-booking-page',
  imports: [CommonModule, BookingCardComponent],
  templateUrl: './booking-page.component.html',
  styleUrl: './booking-page.component.css',
})
export class BookingPageComponent implements OnInit {
  private readonly userId: string = localStorage.getItem('uniqueId')!;
  pageData$?: Observable<BookingCardDataInterface[]>;

  private endpoint: string = 'Workspace';

  constructor(private apiService: ApiService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    var coworkingId = this.route.snapshot.paramMap.get('coworkingId')!;
    this.pageData$ = this.apiService.get<BookingCardDataInterface[]>(
      this.endpoint,
      coworkingId!,
      this.userId
    );
  }
}
