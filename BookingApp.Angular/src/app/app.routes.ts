import { Routes } from '@angular/router';
import { BookingListComponent } from './booking/components/booking-list/booking-list.component';
import { BookingFormComponent } from './booking/components/booking-form/booking-form.component';
import { BookingComponent } from './booking/booking.component';
import { BookingPersonalListComponent } from './booking/components/booking-personal-list/booking-personal-list.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'booking',
    pathMatch: 'full',
  },
  {
    path: 'booking',
    component: BookingComponent,
    children: [
      {
        path: '',
        component: BookingListComponent,
      },
      {
        path: 'add',
        component: BookingFormComponent,
        data: { mode: 'add' },
      },
      {
        path: 'edit/:id',
        component: BookingFormComponent,
        data: { mode: 'edit' },
      },
      {
        path: 'my',
        component: BookingPersonalListComponent,
      },
      {
        path: '**',
        redirectTo: '',
      },
    ],
  },
  {
    path: '**',
    redirectTo: '',
  },
];
