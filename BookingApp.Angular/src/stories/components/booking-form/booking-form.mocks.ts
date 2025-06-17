import { convertToParamMap } from '@angular/router';
import { WorkspaceTypes } from '../../../app/booking/enums/workspace-types.enum';
import { BookingEditFormDataInterface } from '../../../app/booking/interfaces/booking-form/booking-edit-form-data.interface';
import { DateSelectInterface } from '../../../app/booking/interfaces/calendar/date-select.interface';
import { TimeInterface } from '../../../app/booking/interfaces/calendar/time.interface';
import { RoomTypeWithCapacities } from '../../../app/booking/interfaces/room-type-with-capacities.interface';
import { of } from 'rxjs';

export const RoomTypesMock: RoomTypeWithCapacities[] = [
  {
    roomType: {
      id: 3,
      type: WorkspaceTypes.OPENSPACE,
      description: 'A comfortable open space.',
    },
    roomCapacities: [],
  },
  {
    roomType: {
      id: 1,
      type: WorkspaceTypes.MEETINGROOMS,
      description: 'A comfortable meeting room.',
    },
    roomCapacities: [
      {
        id: 1,
        capacity: 10,
      },
      {
        id: 2,
        capacity: 20,
      },
    ],
  },
  {
    roomType: {
      id: 2,
      type: WorkspaceTypes.PRIVATEROOMS,
      description: 'A comfortable private room.',
    },
    roomCapacities: [
      {
        id: 3,
        capacity: 1,
      },
      {
        id: 4,
        capacity: 2,
      },
    ],
  },
];

export const EditPrivateBookingMock: BookingEditFormDataInterface = {
  roomTypes: RoomTypesMock,
  booking: {
    id: 1,
    roomId: 1,
    customerName: 'Name',
    customerEmail: 'Email@gmail.com',
    startDate: '2025-06-17',
    endDate: '2025-06-17',
    startTime: '03:00:00.0000000',
    endTime: '03:30:00.0000000',
  },
  roomType: {
    id: 2,
    type: WorkspaceTypes.PRIVATEROOMS,
    description: 'A comfortable private room.',
  },
  roomCapacity: {
    id: 3,
    capacity: 1,
  },
};

export const DateSelectMock: DateSelectInterface = {
  selectedYear: null,
  selectedMonth: null,
  availableYears: [],
  availableMonths: [],
  availableDays: [],
};

export const timeMock: TimeInterface = {
  time: new Date(2025, 5, 15, 8, 0),
  timeInMinutes: 480,
};

export class CalendarServiceMock {
  readonly lastMinuteOfDay = 1440;
  readonly monthNames = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December',
  ];

  firstAvailableYear = 2025;
  firstAvailableMonth = 5;
  firstAvailableDay = 15;
  firstAvailableTimeInMinutes = 480;

  populateTime(
    chosenDay: number,
    startTime: number | null = null
  ): TimeInterface[] {
    startTime = startTime ? startTime + 30 : 0;
    let hours = startTime ? startTime / 60 : 8;
    let minutes = startTime ? startTime % 60 : 0;
    return [
      {
        timeInMinutes: 480 + startTime,
        time: new Date(2025, 5, 15, hours, minutes),
      },
      {
        timeInMinutes: 510 + startTime,
        time: new Date(2025, 5, 15, hours, minutes + 30),
      },
    ];
  }

  populateStartDates(data: DateSelectInterface): DateSelectInterface {
    return {
      selectedYear: 2025,
      selectedMonth: 5,
      availableYears: [2025],
      availableMonths: [5, 6, 7],
      availableDays: [15, 16, 17],
    };
  }

  populateEndDates(
    data: DateSelectInterface,
    _startYear: number,
    _startMonth: number,
    _startDay: number,
    _maxDays: number
  ): DateSelectInterface {
    return {
      selectedYear: _startYear,
      selectedMonth: _startMonth,
      availableYears: [_startYear],
      availableMonths: Array.from(
        { length: 3 },
        (_, i) => _startMonth + i
      ).filter((m) => m >= 1 && m <= 12),
      availableDays: Array.from({ length: 10 }, (_, i) => _startDay + i).filter(
        (d) => d >= 1 && d <= 31
      ),
    };
  }
}

export class ApiServiceMock {
  get<T>(endpoint: string, id?: string) {
    if (endpoint.includes('edit')) {
      return of(EditPrivateBookingMock);
    }
    return of(RoomTypesMock);
  }

  post<T>(endpoint: string, data: any) {
    return of({ success: true } as T);
  }

  put<T>(endpoint: string, data: any) {
    return of({ success: true } as T);
  }
}

export const ActivatedRouteAddMock = {
  snapshot: {
    data: { mode: 'add' },
    params: { coworkingId: '1' },
    paramMap: convertToParamMap({ coworkingId: '1' }),
  },
  data: of({ mode: 'add' }),
  params: of({ coworkingId: '1' }),
};

export const ActivatedRouteEditMock = {
  snapshot: {
    data: { mode: 'edit' },
    params: { id: '1', coworkingId: '1' },
    paramMap: convertToParamMap({ id: '1', coworkingId: '1' }),
  },
  data: of({ mode: 'edit' }),
  params: of({ id: '1', coworkingId: '1' }),
};
