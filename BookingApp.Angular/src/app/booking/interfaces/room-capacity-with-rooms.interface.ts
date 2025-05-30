import { RoomCapacityInterface } from './room-capacity.interface';
import { RoomInterface } from './room.interface';

export interface RoomCapacityWithRoomsInterface extends RoomCapacityInterface {
  rooms: RoomInterface[];
}
