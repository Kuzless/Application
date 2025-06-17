import { WorkspaceTypes } from '../../../app/booking/enums/workspace-types.enum';
import { BookingInfoInterface } from '../../../app/booking/interfaces/booking-info.interface';

export const mockMeetingRoomBooking: BookingInfoInterface = {
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
    roomTypeId: 1,
    roomCapacityId: 1,
    coworkingId: 1,
  },
  roomType: {
    id: 1,
    type: WorkspaceTypes.MEETINGROOMS,
    description: 'A comfortable meeting room.',
  },
  roomCapacity: {
    id: 1,
    capacity: 10,
  },
};

export const mockPrivateRoomBooking: BookingInfoInterface = {
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
    roomTypeId: 1,
    roomCapacityId: 1,
    coworkingId: 1,
  },
  roomType: {
    id: 1,
    type: WorkspaceTypes.PRIVATEROOMS,
    description: 'A comfortable private room.',
  },
  roomCapacity: {
    id: 1,
    capacity: 2,
  },
};

export const mockOpenSpaceBooking: BookingInfoInterface = {
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
    roomTypeId: 1,
    roomCapacityId: null,
    coworkingId: 1,
  },
  roomType: {
    id: 1,
    type: WorkspaceTypes.OPENSPACE,
    description: 'A comfortable meeting room.',
  },
  roomCapacity: null,
};
