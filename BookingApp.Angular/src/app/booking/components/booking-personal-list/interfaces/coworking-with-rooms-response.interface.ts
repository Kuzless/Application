import { CoworkingInterface } from '../../../shared/interfaces/dto/coworking.interface';
import { UserBookingInfoInterface } from './user-booking-info.interface';

export interface CoworkingWithRoomsResponseInterface {
  coworking: CoworkingInterface;
  bookings: UserBookingInfoInterface[];
}
