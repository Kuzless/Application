import { WorkspaceTypes } from '../../../app/booking/enums/workspace-types.enum';
import { BookingCardDataInterface } from '../../../app/booking/interfaces/booking-page/booking-card-data.interface';

export const mockMeetingRoom: BookingCardDataInterface = {
  roomType: {
    id: 1,
    type: WorkspaceTypes.MEETINGROOMS,
    description: 'A comfortable meeting room.',
  },
  amenities: [
    { id: 1, name: 'wifi' },
    { id: 2, name: 'coffee' },
  ],
  rooms: [
    { id: 1, roomTypeId: 1, roomCapacityId: 1, coworkingId: 1 },
    { id: 2, roomTypeId: 1, roomCapacityId: 1, coworkingId: 1 },
    { id: 3, roomTypeId: 1, roomCapacityId: 2, coworkingId: 1 },
  ],
  roomCapacities: [
    { id: 1, capacity: 10 },
    { id: 2, capacity: 20 },
  ],
  bookingInfos: [
    {
      booking: {
        id: 1,
        roomId: 3,
        customerName: 'Name',
        customerEmail: 'Email',
        startDate: '2025-06-17',
        endDate: '2025-06-17',
        startTime: '03:00:00.0000000',
        endTime: '03:30:00.0000000',
      },
      room: {
        id: 3,
        roomCapacityId: 2,
        roomTypeId: 1,
        coworkingId: 1,
      },
    },
  ],
};

export const mockPrivateRoom: BookingCardDataInterface = {
  roomType: {
    id: 1,
    type: WorkspaceTypes.PRIVATEROOMS,
    description: 'A comfortable private room.',
  },
  amenities: [
    { id: 1, name: 'ac' },
    { id: 2, name: 'gamingconsole' },
  ],
  rooms: [
    { id: 1, roomTypeId: 1, roomCapacityId: 1, coworkingId: 1 },
    { id: 2, roomTypeId: 1, roomCapacityId: 2, coworkingId: 1 },
    { id: 3, roomTypeId: 1, roomCapacityId: 3, coworkingId: 1 },
    { id: 4, roomTypeId: 1, roomCapacityId: 4, coworkingId: 1 },
    { id: 5, roomTypeId: 1, roomCapacityId: 2, coworkingId: 1 },
  ],
  roomCapacities: [
    { id: 1, capacity: 1 },
    { id: 2, capacity: 2 },
    { id: 3, capacity: 5 },
    { id: 4, capacity: 10 },
  ],
  bookingInfos: [],
};

export const mockOpenSpace: BookingCardDataInterface = {
  roomType: {
    id: 1,
    type: WorkspaceTypes.OPENSPACE,
    description: 'A comfortable open space.',
  },
  amenities: [{ id: 1, name: 'wifi' }],
  rooms: [
    { id: 1, roomTypeId: 1, roomCapacityId: null, coworkingId: 1 },
    { id: 2, roomTypeId: 1, roomCapacityId: null, coworkingId: 1 },
    { id: 3, roomTypeId: 1, roomCapacityId: null, coworkingId: 1 },
    { id: 4, roomTypeId: 1, roomCapacityId: null, coworkingId: 1 },
    { id: 5, roomTypeId: 1, roomCapacityId: null, coworkingId: 1 },
    { id: 6, roomTypeId: 1, roomCapacityId: null, coworkingId: 1 },
    { id: 7, roomTypeId: 1, roomCapacityId: null, coworkingId: 1 },
  ],
  roomCapacities: [],
  bookingInfos: [
    {
      booking: {
        id: 1,
        roomId: 1,
        customerName: 'Name',
        customerEmail: 'Email',
        startDate: '2025-06-17',
        endDate: '2025-06-17',
        startTime: '03:00:00.0000000',
        endTime: '03:30:00.0000000',
      },
      room: {
        id: 1,
        roomCapacityId: null,
        roomTypeId: 1,
        coworkingId: 1,
      },
    },
    {
      booking: {
        id: 2,
        roomId: 2,
        customerName: 'Name',
        customerEmail: 'Email',
        startDate: '2025-06-17',
        endDate: '2025-06-17',
        startTime: '03:00:00.0000000',
        endTime: '03:30:00.0000000',
      },
      room: {
        id: 2,
        roomCapacityId: null,
        roomTypeId: 1,
        coworkingId: 1,
      },
    },
  ],
};
