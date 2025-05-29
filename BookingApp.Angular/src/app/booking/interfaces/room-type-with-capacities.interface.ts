import { RoomCapacityInterface } from './room-capacity.interface';

export interface RoomTypeWithCapacitiesInterface {
  id: number;
  type: string;
  roomCapacities: RoomCapacityInterface[];
}
