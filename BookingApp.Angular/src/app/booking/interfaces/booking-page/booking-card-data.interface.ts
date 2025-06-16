import { AmenityInterface } from '../base-dtos/amenity.interface';
import { BookingWithRoomInterface } from '../booking-with-room.interface';
import { RoomTypeInterface } from '../base-dtos/room-type.interface';
import { RoomInterface } from '../base-dtos/room.interface';
import { RoomCapacityInterface } from '../base-dtos/room-capacity.interface';

export interface BookingCardDataInterface {
  roomType: RoomTypeInterface;
  rooms: RoomInterface[];
  roomCapacities: RoomCapacityInterface[];
  amenities: AmenityInterface[];
  bookingInfos: BookingWithRoomInterface[];
}
