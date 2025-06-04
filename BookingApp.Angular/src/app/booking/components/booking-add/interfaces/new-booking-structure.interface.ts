import { RoomCapacityInterface } from '../../../interfaces/dto/room-capacity.interface';
import { RoomTypeInterface } from '../../../interfaces/dto/room-type.interface';

export interface NewBookingStructureInterface {
  roomType: RoomTypeInterface;
  roomCapacities: RoomCapacityInterface[];
}
