import { RoomCapacityInterface } from '../../../shared/interfaces/dto/room-capacity.interface';
import { RoomInterface } from '../../../shared/interfaces/dto/room.interface';

export interface RoomCapacityInfoInterface {
  roomCapacity: RoomCapacityInterface;
  rooms: RoomInterface[];
}
