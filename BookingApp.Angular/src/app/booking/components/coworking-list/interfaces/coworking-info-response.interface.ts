import { AddressInterface } from '../../../shared/interfaces/dto/address.interface';
import { CityInterface } from '../../../shared/interfaces/dto/city.interface';
import { CoworkingInterface } from '../../../shared/interfaces/dto/coworking.interface';
import { RoomTypeWithRoomsInterface } from './room-type-with-rooms.interface';

export interface CoworkingInfoResponseInterface {
  coworking: CoworkingInterface;
  city: CityInterface;
  address: AddressInterface;
  roomTypesWithRooms: RoomTypeWithRoomsInterface[];
}
