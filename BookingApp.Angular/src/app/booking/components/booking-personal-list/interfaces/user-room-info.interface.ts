import { RoomCapacityInterface } from '../../../shared/interfaces/dto/room-capacity.interface';
import { RoomTypeInterface } from '../../../shared/interfaces/dto/room-type.interface';
import { RoomInterface } from '../../../shared/interfaces/dto/room.interface';

export interface UserRoomInfoInterface {
  room: RoomInterface;
  roomType: RoomTypeInterface;
  roomCapacity: RoomCapacityInterface;
}
