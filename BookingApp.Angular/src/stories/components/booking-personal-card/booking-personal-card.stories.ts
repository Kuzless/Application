import { applicationConfig, StoryObj } from '@storybook/angular';
import { BookingPersonalCardComponent } from '../../../app/booking/components/booking-personal-card/booking-personal-card.component';
import {
  mockMeetingRoomBooking,
  mockOpenSpaceBooking,
  mockPrivateRoomBooking,
} from './booking-personal-card.mocks';
import { provideRouter } from '@angular/router';
import { action } from 'storybook/actions';
import { provideHttpClient } from '@angular/common/http';

export default {
  title: 'PersonalBookingCard',
  component: BookingPersonalCardComponent,
  decorators: [
    applicationConfig({
      providers: [provideRouter([]), provideHttpClient()],
    }),
  ],
};

type Story = StoryObj<BookingPersonalCardComponent>;

export const MeetingRoomBooking: Story = {
  args: {
    booking: mockMeetingRoomBooking,
    delete: action('Booking deleted'),
  },
};
export const PrivateRoomBooking: Story = {
  args: {
    booking: mockPrivateRoomBooking,
    delete: action('Booking deleted'),
  },
};
export const OpenSpaceBooking: Story = {
  args: {
    booking: mockOpenSpaceBooking,
    delete: action('Booking deleted'),
  },
};
