import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../shared/services/api.service';
import { CoworkingInfoResponseInterface } from '../../interfaces/coworking-page/coworking-page-data.interface';
import { Observable } from 'rxjs';
import { CoworkingCardComponent } from '../coworking-card/coworking-card.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-coworking-page',
  imports: [CoworkingCardComponent, CommonModule],
  templateUrl: './coworking-page.component.html',
  styleUrl: './coworking-page.component.css',
})
export class CoworkingPageComponent implements OnInit {
  private readonly userId: string = localStorage.getItem('uniqueId')!;
  pageData$?: Observable<CoworkingInfoResponseInterface[]>;

  private endpoint: string = 'Workspace';

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.pageData$ = this.apiService.get<CoworkingInfoResponseInterface[]>(
      this.endpoint
    );
  }
}
