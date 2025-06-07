import { BookingInterface } from '../../../shared/interfaces/dto/booking.interface';
import { RoomCapacityInterface } from '../../../shared/interfaces/dto/room-capacity.interface';
import { RoomTypeInterface } from '../../../shared/interfaces/dto/room-type.interface';
import { NewBookingStructureResponseInterface } from './new-booking-structure-response.interface';

export interface EditBookingResponseInterface {
  booking: BookingInterface;
  roomType: RoomTypeInterface;
  roomCapacity: RoomCapacityInterface;
  roomTypes: NewBookingStructureResponseInterface[];
}
