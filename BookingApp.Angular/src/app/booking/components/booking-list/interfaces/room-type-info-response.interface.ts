import { AmenityInterface } from '../../../shared/interfaces/dto/amenity.interface';
import { BookingInfoInterface } from './booking-info.interface';
import { RoomTypeInterface } from '../../../shared/interfaces/dto/room-type.interface';
import { RoomInterface } from '../../../shared/interfaces/dto/room.interface';
import { RoomCapacityInterface } from '../../../shared/interfaces/dto/room-capacity.interface';

export interface BookingTypeInfoResponseInterface {
  roomType: RoomTypeInterface;
  rooms: RoomInterface[];
  roomCapacities: RoomCapacityInterface[];
  amenities: AmenityInterface[];
  bookingInfos: BookingInfoInterface[];
}
