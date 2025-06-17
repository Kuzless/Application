import { WorkspaceTypes } from '../../../app/booking/enums/workspace-types.enum';
import { CoworkingPageDataInterface } from '../../../app/booking/interfaces/coworking-page/coworking-page-data.interface';

export const mockCoworkingCard: CoworkingPageDataInterface = {
  coworking: {
    id: 1,
    name: 'Dnipro Works',
    description: 'Coworking description',
    addressId: 1,
  },
  address: {
    id: 1,
    houseNumber: '10',
    street: 'Test Street',
    cityId: 1,
  },
  city: {
    id: 1,
    name: 'Dnipro',
  },
  roomTypesWithRooms: [
    {
      roomType: {
        id: 1,
        type: WorkspaceTypes.MEETINGROOMS,
        description: 'A comfortable meeting room.',
      },
      rooms: [
        {
          id: 1,
          roomCapacityId: 1,
          roomTypeId: 1,
          coworkingId: 1,
        },
        {
          id: 2,
          roomCapacityId: 1,
          roomTypeId: 1,
          coworkingId: 1,
        },
        {
          id: 3,
          roomCapacityId: 1,
          roomTypeId: 1,
          coworkingId: 1,
        },
      ],
    },
    {
      roomType: {
        id: 2,
        type: WorkspaceTypes.PRIVATEROOMS,
        description: 'A comfortable private room.',
      },
      rooms: [
        {
          id: 4,
          roomCapacityId: 1,
          roomTypeId: 2,
          coworkingId: 1,
        },
        {
          id: 5,
          roomCapacityId: 1,
          roomTypeId: 2,
          coworkingId: 1,
        },
      ],
    },
    {
      roomType: {
        id: 3,
        type: WorkspaceTypes.OPENSPACE,
        description: 'A comfortable open space.',
      },
      rooms: [
        {
          id: 6,
          roomCapacityId: null,
          roomTypeId: 3,
          coworkingId: 1,
        },
        {
          id: 7,
          roomCapacityId: null,
          roomTypeId: 3,
          coworkingId: 1,
        },
        {
          id: 8,
          roomCapacityId: null,
          roomTypeId: 3,
          coworkingId: 1,
        },
      ],
    },
  ],
};
