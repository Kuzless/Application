import { BookingInterface } from './booking.interface';

export interface BookingWithRoomTypeInterface extends BookingInterface {
  typeId: number;
}
