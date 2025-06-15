import { BookingInterface } from '../../../shared/interfaces/dto/booking.interface';
import { RoomCapacityInterface } from '../../../shared/interfaces/dto/room-capacity.interface';
import { RoomTypeInterface } from '../../../shared/interfaces/dto/room-type.interface';
import { RoomInterface } from '../../../shared/interfaces/dto/room.interface';

export interface UserBookingInfoInterface {
  booking: BookingInterface;
  room: RoomInterface;
  roomType: RoomTypeInterface;
  roomCapacity: RoomCapacityInterface;
}
