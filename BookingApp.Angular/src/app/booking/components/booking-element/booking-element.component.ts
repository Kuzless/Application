import { Component, Input, OnInit } from '@angular/core';
import { RoomTypeInfoInterface } from '../../interfaces/booking-main/room-type-info.interface';
import { CommonModule } from '@angular/common';
import { FormatImgPipe } from './pipes/format-img.pipe';
import { RoomInterface } from '../../interfaces/room.interface';

@Component({
  selector: 'app-booking-element',
  imports: [CommonModule, FormatImgPipe],
  templateUrl: './booking-element.component.html',
  styleUrl: './booking-element.component.css',
})
export class BookingElementComponent implements OnInit {
  @Input() booking?: RoomTypeInfoInterface;

  rooms: RoomInterface[] = [];
  iconsUrl: string = 'booking/booking-element/icons/';
  imagesUrl: string = 'booking/booking-element/images/';
  iconsFormat: string = '.svg';
  imagesFormat: string = '.png';

  mainImageName: string = '1';

  ngOnInit(): void {
    this.booking?.roomCapacities.forEach((capacity) =>
      capacity.rooms.forEach((room) => this.rooms.push(room))
    );
  }
}
