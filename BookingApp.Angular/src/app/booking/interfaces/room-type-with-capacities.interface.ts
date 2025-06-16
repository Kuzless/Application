import { RoomCapacityInterface } from './base-dtos/room-capacity.interface';
import { RoomTypeInterface } from './base-dtos/room-type.interface';

export interface RoomTypeWithCapacities {
  roomType: RoomTypeInterface;
  roomCapacities: RoomCapacityInterface[];
}
