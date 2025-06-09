import { BookingInterface } from '../../../shared/interfaces/dto/booking.interface';
import { RoomInterface } from '../../../shared/interfaces/dto/room.interface';

export interface BookingInfoInterface {
  booking: BookingInterface;
  room: RoomInterface;
}
