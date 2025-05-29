import { AmenityInterface } from './amenity.interface';
import { BookingWithRoomTypeInterface } from './booking-with-room-type.interface';
import { RoomTypeWithCapacitiesInterface } from './room-type-with-capacities.interface';

export interface RoomTypeInfoWithUserBookedInterface
  extends RoomTypeWithCapacitiesInterface {
  amenities: AmenityInterface[];
  bookingsWithRoomTypes: BookingWithRoomTypeInterface[];
}
