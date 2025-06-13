import { RoomTypeInterface } from '../../../shared/interfaces/dto/room-type.interface';
import { RoomInterface } from '../../../shared/interfaces/dto/room.interface';

export interface RoomTypeWithRoomsInterface {
  roomType: RoomTypeInterface;
  rooms: RoomInterface[];
}
