import { Routes } from '@angular/router';
import { BookingPageComponent } from './booking/components/booking-page/booking-page.component';
import { BookingFormComponent } from './booking/components/booking-form/booking-form.component';
import { BookingComponent } from './booking/booking.component';
import { BookingPersonalPageComponent } from './booking/components/booking-personal-page/booking-personal-page.component';
import { CoworkingPageComponent } from './booking/components/coworking-page/coworking-page.component';

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
        component: CoworkingPageComponent,
      },
      {
        path: 'my',
        component: BookingPersonalPageComponent,
      },
      {
        path: ':coworkingId/add',
        component: BookingFormComponent,
        data: { mode: 'add' },
      },
      {
        path: ':coworkingId/edit/:id',
        component: BookingFormComponent,
        data: { mode: 'edit' },
      },
      {
        path: ':coworkingId',
        component: BookingPageComponent,
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
