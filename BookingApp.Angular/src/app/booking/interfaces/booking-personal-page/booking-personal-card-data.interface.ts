import { CoworkingInterface } from '../base-dtos/coworking.interface';
import { BookingInfoInterface } from '../booking-info.interface';

export interface BookingPersonalCardDataInterface {
  coworking: CoworkingInterface;
  bookings: BookingInfoInterface[];
}
