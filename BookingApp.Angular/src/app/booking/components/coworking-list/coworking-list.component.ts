import { Component, OnInit } from '@angular/core';
import { BookingApiService } from '../../shared/services/booking-api.service';
import { CoworkingInfoResponseInterface } from './interfaces/coworking-info-response.interface';
import { Observable } from 'rxjs';
import { CoworkingElementComponent } from './coworking-element/coworking-element.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-coworking-list',
  imports: [CoworkingElementComponent, CommonModule],
  templateUrl: './coworking-list.component.html',
  styleUrl: './coworking-list.component.css',
})
export class CoworkingListComponent implements OnInit {
  private readonly userId: string = localStorage.getItem('uniqueId')!;
  pageData$?: Observable<CoworkingInfoResponseInterface[]>;

  private endpoint: string = 'Workspace';

  constructor(private apiService: BookingApiService) {}

  ngOnInit(): void {
    this.pageData$ = this.apiService.get<CoworkingInfoResponseInterface[]>(
      this.endpoint
    );
  }
}
