import { BookingInterface } from '../../../interfaces/dto/booking.interface';
import { RoomInterface } from '../../../interfaces/dto/room.interface';

export interface BookingInfoInterface {
  booking: BookingInterface;
  room: RoomInterface;
}
