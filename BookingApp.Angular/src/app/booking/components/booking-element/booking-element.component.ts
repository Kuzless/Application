import { Component, Input, OnInit } from '@angular/core';
import { RoomTypeInfoWithUserBookedInterface } from '../../interfaces/room-type-info-with-user-booked.interface';
import { CommonModule } from '@angular/common';
import { FormatIconPipe } from './pipes/format-icon.pipe';
import { RoomInterface } from '../../interfaces/room.interface';

@Component({
  selector: 'app-booking-element',
  imports: [CommonModule, FormatIconPipe],
  templateUrl: './booking-element.component.html',
  styleUrl: './booking-element.component.css',
})
export class BookingElementComponent implements OnInit {
  @Input() booking?: RoomTypeInfoWithUserBookedInterface;
  rooms: RoomInterface[] = [];
  iconsUrl: string = 'booking/booking-element/icons/';
  iconsFormat: string = '.svg';
  ngOnInit(): void {
    this.booking?.roomCapacities.forEach((capacity) =>
      capacity.rooms.forEach((room) => this.rooms.push(room))
    );
  }
}
