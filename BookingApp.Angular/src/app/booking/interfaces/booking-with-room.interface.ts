import { BookingInterface } from './booking.interface';
import { RoomInterface } from './room.interface';

export interface BookingWithRoomInterface extends BookingInterface {
  room: RoomInterface;
}
