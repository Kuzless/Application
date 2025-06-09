import { Component, Output, EventEmitter, Input } from '@angular/core';
import { BookingApiService } from '../../../../shared/services/booking-api.service';

@Component({
  selector: 'app-confirm',
  imports: [],
  templateUrl: './confirm.component.html',
  styleUrl: './confirm.component.css',
})
export class ConfirmComponent {
  @Input() id!: number;
  @Output() closed = new EventEmitter<void>();
  @Output() deleted = new EventEmitter<void>();

  private readonly endpoint: string = 'Booking';

  readonly iconsUrl: string = 'booking/icons/';
  readonly iconsFormat: string = '.svg';
  readonly iconName: string = 'trash';

  constructor(private apiService: BookingApiService) {}

  close() {
    this.closed.emit();
  }

  deleteBooking() {
    this.apiService.delete(this.endpoint, this.id).subscribe();
    this.deleted.emit();
  }
}
