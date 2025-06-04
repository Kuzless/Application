import { AmenityInterface } from '../../../interfaces/dto/amenity.interface';
import { BookingInfoInterface } from './booking-info.interface';
import { RoomCapacityInfoInterface } from './room-capacity-info.interface';
import { RoomTypeInterface } from '../../../interfaces/dto/room-type.interface';

export interface RoomTypeInfoInterface {
  roomType: RoomTypeInterface;
  roomCapacities: RoomCapacityInfoInterface[];
  amenities: AmenityInterface[];
  bookingInfos: BookingInfoInterface[];
}
