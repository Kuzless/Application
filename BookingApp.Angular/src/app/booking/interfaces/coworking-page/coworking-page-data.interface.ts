import { AddressInterface } from '../base-dtos/address.interface';
import { CityInterface } from '../base-dtos/city.interface';
import { CoworkingInterface } from '../base-dtos/coworking.interface';
import { RoomTypeWithRoomsInterface } from '../room-type-with-rooms.interface';

export interface CoworkingPageDataInterface {
  coworking: CoworkingInterface;
  city: CityInterface;
  address: AddressInterface;
  roomTypesWithRooms: RoomTypeWithRoomsInterface[];
}
