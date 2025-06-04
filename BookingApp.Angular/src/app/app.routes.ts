import { Routes } from '@angular/router';
import { BookingComponent } from './booking/components/booking/booking.component';
import { BookingAddComponent } from './booking/components/booking-add/booking-add.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'bookings',
    pathMatch: 'full',
  },
  {
    path: 'bookings',
    component: BookingComponent,
  },
  {
    path: 'add',
    component: BookingAddComponent,
  },
];
