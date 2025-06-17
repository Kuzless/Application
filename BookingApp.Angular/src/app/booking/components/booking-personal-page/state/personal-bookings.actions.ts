import { createAction, props } from '@ngrx/store';
import { BookingPersonalCardDataInterface } from '../../../interfaces/booking-personal-page/booking-personal-card-data.interface';

export const loadCoworkings = createAction(
  '[Personal Booking Page] Load Coworkings',
  props<{ endpoint: string; userId: string }>()
);

export const loadCoworkingsSuccess = createAction(
  '[Personal Booking Page] Load Coworkings Success',
  props<{
    coworkings: BookingPersonalCardDataInterface[];
  }>()
);

export const loadCoworkingsFailure = createAction(
  '[Personal Booking Page] Load Coworkings Failure',
  props<{
    error: any;
  }>()
);

export const deleteBooking = createAction(
  '[Personal Booking Page] Delete Booking',
  props<{ endpoint: string; id: number }>()
);

export const deleteBookingSuccess = createAction(
  '[Personal Booking Page] Delete Booking Success',
  props<{ id: number }>()
);

export const deleteBookingFailure = createAction(
  '[Personal Booking Page] Delete Booking Failure',
  props<{
    error: any;
  }>()
);
