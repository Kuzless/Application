import { Component, Input, OnInit } from '@angular/core';
import { RoomTypeInfoInterface } from '../interfaces/room-type-info.interface';
import { CommonModule } from '@angular/common';
import { FormatImgPipe } from '../../../pipes/format-img.pipe';
import { RoomInterface } from '../../../interfaces/dto/room.interface';
import { RoomCapacityInfoInterface } from '../interfaces/room-capacity-info.interface';

@Component({
  selector: 'app-booking-element',
  imports: [CommonModule, FormatImgPipe],
  templateUrl: './booking-element.component.html',
  styleUrl: './booking-element.component.css',
})
export class BookingElementComponent implements OnInit {
  @Input() booking?: RoomTypeInfoInterface;

  rooms: RoomInterface[] = [];
  capacitiesInfo: RoomCapacityInfoInterface[] = [];

  iconsUrl: string = 'booking/booking-element/icons/';
  imagesUrl: string = 'booking/booking-element/images/';
  iconsFormat: string = '.svg';
  imagesFormat: string = '.png';

  mainImageName: string = '1';

  ngOnInit(): void {
    this.booking?.roomCapacities.forEach((capacity) => {
      this.capacitiesInfo.push(capacity);
      capacity.rooms.forEach((room) => this.rooms.push(room));
    });
  }
}
