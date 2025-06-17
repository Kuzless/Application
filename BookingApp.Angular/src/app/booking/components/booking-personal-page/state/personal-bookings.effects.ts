import { Injectable, inject } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, mergeMap } from 'rxjs/operators';
import { ApiService } from '../../../../shared/services/api.service';
import { BookingPersonalCardDataInterface } from '../../../interfaces/booking-personal-page/booking-personal-card-data.interface';
import {
  deleteBooking,
  deleteBookingFailure,
  deleteBookingSuccess,
  loadCoworkings,
  loadCoworkingsFailure,
  loadCoworkingsSuccess,
} from './personal-bookings.actions';

@Injectable()
export class PersonalBookingsEffects {
  private actions$: Actions = inject(Actions);
  private apiService: ApiService = inject(ApiService);

  loadCoworkings$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadCoworkings),
      mergeMap((action) =>
        this.apiService
          .get<BookingPersonalCardDataInterface[]>(
            action.endpoint,
            action.userId
          )
          .pipe(
            map((coworkings) => loadCoworkingsSuccess({ coworkings })),
            catchError((error) => of(loadCoworkingsFailure({ error })))
          )
      )
    )
  );

  deleteBooking$ = createEffect(() =>
    this.actions$.pipe(
      ofType(deleteBooking),
      mergeMap((action) =>
        this.apiService.delete(action.endpoint, action.id).pipe(
          map(() => deleteBookingSuccess({ id: action.id })),
          catchError((error) => of(deleteBookingFailure({ error })))
        )
      )
    )
  );
}
