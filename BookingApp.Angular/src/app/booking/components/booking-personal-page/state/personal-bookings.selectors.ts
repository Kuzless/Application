import { createFeatureSelector, createSelector } from '@ngrx/store';
import { PersonalBookingPageState } from './personal-bookings.reducer';

const selectCoworkingsFeature =
  createFeatureSelector<PersonalBookingPageState>('personalCoworkings');

export const selectCoworkings = createSelector(
  selectCoworkingsFeature,
  (state) => state.coworkings
);
