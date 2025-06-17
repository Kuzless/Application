import { createReducer, on } from '@ngrx/store';
import { BookingPersonalCardDataInterface } from '../../../interfaces/booking-personal-page/booking-personal-card-data.interface';
import {
  deleteBookingSuccess,
  loadCoworkingsSuccess,
  loadCoworkingsFailure,
  deleteBookingFailure,
} from './personal-bookings.actions';

export interface PersonalBookingPageState {
  coworkings: BookingPersonalCardDataInterface[];
  error: any;
}

export const initialState: PersonalBookingPageState = {
  coworkings: [],
  error: null,
};

export const personalBookingReducer = createReducer(
  initialState,
  on(loadCoworkingsSuccess, (state, { coworkings }) => ({
    ...state,
    coworkings,
  })),
  on(loadCoworkingsFailure, (state, { error }) => ({ ...state, error })),
  on(deleteBookingSuccess, (state, { id }) => ({
    ...state,
    coworkings: state.coworkings
      .map((coworking) => ({
        ...coworking,
        bookings: coworking.bookings.filter(
          (booking) => booking.booking.id !== id
        ),
      }))
      .filter((coworking) => coworking.bookings.length > 0),
  })),
  on(deleteBookingFailure, (state, { error }) => ({ ...state, error }))
);
