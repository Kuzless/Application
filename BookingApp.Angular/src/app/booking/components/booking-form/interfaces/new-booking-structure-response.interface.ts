import { RoomCapacityInterface } from '../../../shared/interfaces/dto/room-capacity.interface';
import { RoomTypeInterface } from '../../../shared/interfaces/dto/room-type.interface';

export interface NewBookingStructureResponseInterface {
  roomType: RoomTypeInterface;
  roomCapacities: RoomCapacityInterface[];
}
