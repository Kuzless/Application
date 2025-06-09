import { BookingInterface } from '../../../shared/interfaces/dto/booking.interface';
import { UserRoomInfoInterface } from './user-room-info.interface';

export interface UserBookingInfoResponseInterface {
  booking: BookingInterface;
  userRoomInfo: UserRoomInfoInterface;
}
