import { BookingInterface } from '../booking.interface';
import { RoomInterface } from '../room.interface';

export interface BookingInfoInterface {
  booking: BookingInterface;
  room: RoomInterface;
}
