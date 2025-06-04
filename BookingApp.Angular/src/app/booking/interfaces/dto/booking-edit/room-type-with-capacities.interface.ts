import { RoomCapacityInterface } from '../room-capacity.interface';
import { RoomTypeInterface } from '../room-type.interface';

export interface RoomTypeWithCapacitiesInterface extends RoomTypeInterface {
  roomCapacities: RoomCapacityInterface[];
}
