import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../shared/services/api.service';
import { BookingTypeInfoResponseInterface } from './interfaces/room-type-info-response.interface';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { BookingElementComponent } from './booking-element/booking-element.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-booking-list',
  imports: [CommonModule, BookingElementComponent],
  templateUrl: './booking-list.component.html',
  styleUrl: './booking-list.component.css',
})
export class BookingListComponent implements OnInit {
  private readonly userId: string = localStorage.getItem('uniqueId')!;
  pageData$?: Observable<BookingTypeInfoResponseInterface[]>;

  private endpoint: string = 'Workspace';

  constructor(private apiService: ApiService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    var coworkingId = this.route.snapshot.paramMap.get('coworkingId')!;
    this.pageData$ = this.apiService.get<BookingTypeInfoResponseInterface[]>(
      this.endpoint,
      coworkingId!,
      this.userId
    );
  }
}
