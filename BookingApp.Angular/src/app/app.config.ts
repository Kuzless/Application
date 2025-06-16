import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { personalBookingReducer } from './booking/components/booking-personal-page/state/personal-bookings.reducer';
import { PersonalBookingsEffects } from './booking/components/booking-personal-page/state/personal-bookings.effects';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(),
    provideStore({ personalCoworkings: personalBookingReducer }),
    provideEffects([PersonalBookingsEffects]),
  ],
};
