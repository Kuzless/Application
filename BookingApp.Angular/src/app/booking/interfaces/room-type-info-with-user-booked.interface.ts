import { AmenityInterface } from './amenity.interface';
import { BookingWithRoomTypeInterface } from './booking-with-room-type.interface';
import { RoomTypeWithCapacitiesNRoomsInterface } from './room-type-with-capacities-n-rooms.interface';

export interface RoomTypeInfoWithUserBookedInterface
  extends RoomTypeWithCapacitiesNRoomsInterface {
  amenities: AmenityInterface[];
  bookingsWithRoomTypes: BookingWithRoomTypeInterface[];
}
