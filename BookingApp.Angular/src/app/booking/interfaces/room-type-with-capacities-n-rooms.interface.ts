import { RoomCapacityWithRoomsInterface } from './room-capacity-with-rooms.interface';
import { RoomTypeInterface } from './room-type.interface';

export interface RoomTypeWithCapacitiesNRoomsInterface
  extends RoomTypeInterface {
  roomCapacities: RoomCapacityWithRoomsInterface[];
}
