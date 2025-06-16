import { Component, Output, EventEmitter, Input } from '@angular/core';
import { ApiService } from '../../../../shared/services/api.service';

@Component({
  selector: 'app-confirm',
  imports: [],
  templateUrl: './confirm.component.html',
  styleUrl: './confirm.component.css',
})
export class ConfirmComponent {
  @Output() closed = new EventEmitter<void>();
  @Output() delete = new EventEmitter<void>();

  readonly iconsUrl: string = 'booking/icons/';
  readonly iconsFormat: string = '.svg';
  readonly iconName: string = 'trash';

  constructor(private apiService: ApiService) {}

  close() {
    this.closed.emit();
  }

  deleteBooking() {
    this.delete.emit();
  }
}
