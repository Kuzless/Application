import { BookingCardComponent } from '../../../app/booking/components/booking-card/booking-card.component';
import { applicationConfig, StoryObj } from '@storybook/angular';
import {
  mockMeetingRoom,
  mockOpenSpace,
  mockPrivateRoom,
} from './booking-card.mocks';
import { provideRouter } from '@angular/router';

export default {
  title: 'BookingCard',
  component: BookingCardComponent,
  decorators: [
    applicationConfig({
      providers: [provideRouter([])],
    }),
  ],
};

type Story = StoryObj<BookingCardComponent>;

export const MeetingRoom: Story = {
  args: {
    bookingType: mockMeetingRoom,
  },
};
export const OpenSpace: Story = {
  args: {
    bookingType: mockOpenSpace,
  },
};
export const PrivateRoom: Story = {
  args: {
    bookingType: mockPrivateRoom,
  },
};
