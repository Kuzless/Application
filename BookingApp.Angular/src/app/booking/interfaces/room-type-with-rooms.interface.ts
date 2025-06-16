import { RoomTypeInterface } from './base-dtos/room-type.interface';
import { RoomInterface } from './base-dtos/room.interface';

export interface RoomTypeWithRoomsInterface {
  roomType: RoomTypeInterface;
  rooms: RoomInterface[];
}
