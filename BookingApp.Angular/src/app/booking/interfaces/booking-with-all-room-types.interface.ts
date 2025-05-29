import { BookingInterface } from './booking.interface';
import { RoomTypeWithCapacitiesInterface } from './room-type-with-capacities.interface';

export interface BookingWithAllRoomTypesInterface extends BookingInterface {
  roomTypes: RoomTypeWithCapacitiesInterface[];
}
