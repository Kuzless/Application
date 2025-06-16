import { BookingInterface } from './base-dtos/booking.interface';
import { RoomInterface } from './base-dtos/room.interface';

export interface BookingWithRoomInterface {
  booking: BookingInterface;
  room: RoomInterface;
}
