import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-failure',
  imports: [],
  templateUrl: './failure.component.html',
  styleUrl: './failure.component.css',
})
export class FailureComponent {
  @Output() closed = new EventEmitter<void>();

  readonly iconsUrl: string = 'booking/icons/';
  readonly iconsFormat: string = '.svg';
  readonly iconName: string = 'failure';

  close() {
    this.closed.emit();
  }
}
