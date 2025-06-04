import { RoomCapacityInterface } from '../../../interfaces/dto/room-capacity.interface';
import { RoomInterface } from '../../../interfaces/dto/room.interface';

export interface RoomCapacityInfoInterface {
  roomCapacity: RoomCapacityInterface;
  rooms: RoomInterface[];
}
