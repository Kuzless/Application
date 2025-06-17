import {
  applicationConfig,
  moduleMetadata,
  StoryObj,
} from '@storybook/angular';
import { BookingFormComponent } from '../../../app/booking/components/booking-form/booking-form.component';
import { ActivatedRoute, provideRouter } from '@angular/router';
import { CalendarService } from '../../../app/booking/services/calendar.service';
import {
  ActivatedRouteAddMock,
  ActivatedRouteEditMock,
  ApiServiceMock,
  CalendarServiceMock,
  RoomTypesMock,
} from './booking-form.mocks';
import { provideHttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { ApiService } from '../../../app/shared/services/api.service';

export default {
  title: 'BookingForm',
  component: BookingFormComponent,
  decorators: [
    applicationConfig({
      providers: [
        provideRouter([{ path: '**', redirectTo: '', pathMatch: 'full' }]),
        provideHttpClient(),
      ],
    }),
    moduleMetadata({
      providers: [
        { provide: CalendarService, useClass: CalendarServiceMock },
        { provide: ApiService, useClass: ApiServiceMock },
      ],
    }),
  ],
};

type Story = StoryObj<BookingFormComponent>;

export const AddForm: Story = {
  args: {
    roomTypes$: of(RoomTypesMock),
  },
  decorators: [
    applicationConfig({
      providers: [
        {
          provide: ActivatedRoute,
          useValue: ActivatedRouteAddMock,
        },
      ],
    }),
  ],
};

export const EditForm: Story = {
  args: {
    roomTypes$: of(RoomTypesMock),
  },
  decorators: [
    applicationConfig({
      providers: [
        {
          provide: ActivatedRoute,
          useValue: ActivatedRouteEditMock,
        },
      ],
    }),
  ],
};
