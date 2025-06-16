import { Component, Input } from '@angular/core';
import { BookingCardDataInterface } from '../../interfaces/booking-page/booking-card-data.interface';
import { CommonModule } from '@angular/common';
import { FormatImgPipe } from '../../pipes/format-img.pipe';
import { RoomInterface } from '../../interfaces/base-dtos/room.interface';
import { RouterLink } from '@angular/router';
import { WorkspaceTypes } from '../../enums/workspace-types.enum';
import { BookingWithRoomInterface } from '../../interfaces/booking-with-room.interface';

@Component({
  selector: 'app-booking-card',
  imports: [CommonModule, FormatImgPipe, RouterLink],
  templateUrl: './booking-card.component.html',
  styleUrl: './booking-card.component.css',
})
export class BookingCardComponent {
  @Input() bookingType?: BookingCardDataInterface;

  readonly iconsUrl: string = 'booking/booking-element/icons/';
  readonly imagesUrl: string = 'booking/booking-element/images/';
  readonly iconsFormat: string = '.svg';
  readonly imagesFormat: string = '.png';
  readonly addBookingRoute: string = 'add';

  readonly checkmarkImageName: string = 'done';

  mainImageName: string = '1';

  isSpecificType(bookingType: BookingCardDataInterface | undefined): boolean {
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
    bookingInfos: BookingWithRoomInterface[] | undefined
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

  getRoomsByCapacity(capacityId: number): RoomInterface[] {
    return (
      this.bookingType?.rooms.filter((r) => r.roomCapacityId === capacityId) ||
      []
    );
  }
}
