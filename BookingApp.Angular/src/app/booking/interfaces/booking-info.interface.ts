import { BookingInterface } from './base-dtos/booking.interface';
import { RoomCapacityInterface } from './base-dtos/room-capacity.interface';
import { RoomTypeInterface } from './base-dtos/room-type.interface';
import { RoomInterface } from './base-dtos/room.interface';

export interface BookingInfoInterface {
  booking: BookingInterface;
  room: RoomInterface;
  roomType: RoomTypeInterface;
  roomCapacity: RoomCapacityInterface;
}
