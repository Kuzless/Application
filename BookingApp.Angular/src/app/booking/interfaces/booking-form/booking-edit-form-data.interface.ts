import { BookingInterface } from '../base-dtos/booking.interface';
import { RoomCapacityInterface } from '../base-dtos/room-capacity.interface';
import { RoomTypeInterface } from '../base-dtos/room-type.interface';
import { RoomTypeWithCapacities } from '../room-type-with-capacities.interface';

export interface BookingEditFormDataInterface {
  booking: BookingInterface;
  roomType: RoomTypeInterface;
  roomCapacity: RoomCapacityInterface;
  roomTypes: RoomTypeWithCapacities[];
}
