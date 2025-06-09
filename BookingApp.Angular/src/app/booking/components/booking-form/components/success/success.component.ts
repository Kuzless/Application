import { Component, Input, Output, EventEmitter } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-success',
  imports: [RouterLink],
  templateUrl: './success.component.html',
  styleUrl: './success.component.css',
})
export class SuccessComponent {
  @Input() email?: string;
  @Output() closed = new EventEmitter<void>();

  readonly iconsUrl: string = 'booking/icons/';
  readonly iconsFormat: string = '.svg';
  readonly iconName: string = 'success';

  close() {
    this.closed.emit();
  }
}
