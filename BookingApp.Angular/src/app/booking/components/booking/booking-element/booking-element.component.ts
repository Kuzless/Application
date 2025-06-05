import { Component, Input, OnInit } from '@angular/core';
import { BookingTypeInfoInterface } from '../interfaces/room-type-info.interface';
import { CommonModule } from '@angular/common';
import { FormatImgPipe } from '../../../pipes/format-img.pipe';
import { RoomInterface } from '../../../interfaces/dto/room.interface';
import { RoomCapacityInfoInterface } from '../interfaces/room-capacity-info.interface';
import { RouterLink } from '@angular/router';
import { WorkspaceTypes } from '../../../enums/workspace-types.enum';
import { BookingInfoInterface } from '../interfaces/booking-info.interface';

@Component({
  selector: 'app-booking-element',
  imports: [CommonModule, FormatImgPipe, RouterLink],
  templateUrl: './booking-element.component.html',
  styleUrl: './booking-element.component.css',
})
export class BookingElementComponent implements OnInit {
  @Input() bookingType?: BookingTypeInfoInterface;

  rooms: RoomInterface[] = [];
  capacitiesInfo: RoomCapacityInfoInterface[] = [];

  readonly iconsUrl: string = 'booking/booking-element/icons/';
  readonly imagesUrl: string = 'booking/booking-element/images/';
  readonly iconsFormat: string = '.svg';
  readonly imagesFormat: string = '.png';
  readonly addBookingRoute: string = '../add';

  mainImageName: string = '1';

  ngOnInit(): void {
    this.bookingType?.roomCapacities.forEach((capacity) => {
      this.capacitiesInfo.push(capacity);
    });
    this.bookingType?.rooms.forEach((room) => {
      this.rooms.push(room);
    });
  }

  isSpecificType(bookingType: BookingTypeInfoInterface | undefined): boolean {
    if (!bookingType) {
      return false;
    }
    if (bookingType.roomType.type === WorkspaceTypes.OPENSPACE) {
      return true;
    }
    return false;
  }

  // grouping desks if booked for same day
  calculateDesks(
    bookingInfos: BookingInfoInterface[] | undefined
  ): [[string, string], number][] {
    if (!bookingInfos) {
      return [];
    }
    bookingInfos.sort(
      (a, b) =>
        new Date(a.booking.startDate).getTime() -
        new Date(b.booking.startDate).getTime()
    );
    let previousStartDate = bookingInfos[0].booking.startDate;
    let previousEndDate = bookingInfos[0].booking.endDate;
    let i = 0;
    let result: [[string, string], number][] = [];
    bookingInfos.forEach((bookingInfo) => {
      if (
        bookingInfo.booking.startDate !== previousStartDate ||
        bookingInfo.booking.endDate !== previousEndDate
      ) {
        previousStartDate = bookingInfo.booking.startDate;
        previousEndDate = bookingInfo.booking.endDate;
        i++;
      }

      if (!result[i]) {
        result[i] = [
          [bookingInfo.booking.startDate, bookingInfo.booking.endDate],
          1,
        ];
      } else {
        result[i][1]++;
      }
    });
    return result;
  }
}
