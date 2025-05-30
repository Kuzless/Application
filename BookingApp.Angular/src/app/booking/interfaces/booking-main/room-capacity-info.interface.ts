import { RoomCapacityInterface } from '../room-capacity.interface';
import { RoomInterface } from '../room.interface';

export interface RoomCapacityInfoInterface {
  roomCapacity: RoomCapacityInterface;
  rooms: RoomInterface[];
}
