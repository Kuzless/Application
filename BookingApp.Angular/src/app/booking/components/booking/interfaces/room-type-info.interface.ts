import { AmenityInterface } from '../../../interfaces/dto/amenity.interface';
import { BookingInfoInterface } from './booking-info.interface';
import { RoomCapacityInfoInterface } from './room-capacity-info.interface';
import { RoomTypeInterface } from '../../../interfaces/dto/room-type.interface';
import { RoomInterface } from '../../../interfaces/dto/room.interface';

export interface BookingTypeInfoInterface {
  roomType: RoomTypeInterface;
  rooms: RoomInterface[];
  roomCapacities: RoomCapacityInfoInterface[];
  amenities: AmenityInterface[];
  bookingInfos: BookingInfoInterface[];
}
