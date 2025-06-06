import { AmenityInterface } from '../../../shared/interfaces/dto/amenity.interface';
import { BookingInfoInterface } from './booking-info.interface';
import { RoomCapacityInfoInterface } from './room-capacity-info.interface';
import { RoomTypeInterface } from '../../../shared/interfaces/dto/room-type.interface';
import { RoomInterface } from '../../../shared/interfaces/dto/room.interface';

export interface BookingTypeInfoResponseInterface {
  roomType: RoomTypeInterface;
  rooms: RoomInterface[];
  roomCapacities: RoomCapacityInfoInterface[];
  amenities: AmenityInterface[];
  bookingInfos: BookingInfoInterface[];
}
