import { Component, OnInit } from '@angular/core';
import { CalendarService } from './interfaces/services/calendar.service';
import { CommonModule, DatePipe } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { TimeInterface } from './interfaces/calendar/time.interface';
import { DateSelectInterface } from './interfaces/calendar/date-select.interface';
import { Observable, tap, map, catchError, throwError } from 'rxjs';
import { NewBookingStructureResponseInterface } from './interfaces/new-booking-structure-response.interface';
import { BookingApiService } from '../../shared/services/booking-api.service';
import { WorkspaceTypes } from '../../shared/enums/workspace-types.enum';
import { RoomCapacityInterface } from '../../shared/interfaces/dto/room-capacity.interface';
import { AddBookingCommandInterface } from './interfaces/add-booking-command.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { EditBookingResponseInterface } from './interfaces/edit-booking-response.interface';
import { BookingInterface } from '../../shared/interfaces/dto/booking.interface';

@Component({
  selector: 'app-booking-form',
  imports: [CommonModule, ReactiveFormsModule, DatePipe],
  templateUrl: './booking-form.component.html',
  styleUrl: './booking-form.component.css',
})
export class BookingFormComponent implements OnInit {
  private readonly userId: string = localStorage.getItem('uniqueId')!;
  private readonly mode: string;
  private readonly endpoint: string = 'Booking/';
  bookingId?: number;

  // how many years should be populated into startDate
  readonly numberOfYears: number = 5;

  roomTypes$!: Observable<NewBookingStructureResponseInterface[]>;
  bookingForm: FormGroup;

  // flags for input fields focus
  nameFocus: boolean = false;
  emailFocus: boolean = false;

  // flag that indicates if roomType supposed to have rooms
  hasRooms: boolean = false;

  startDates: DateSelectInterface = {
    availableYears: [],
    availableMonths: [],
    availableDays: [],
    selectedYear: null,
    selectedMonth: null,
  };

  endDates: DateSelectInterface = {
    availableYears: [],
    availableMonths: [],
    availableDays: [],
    selectedYear: null,
    selectedMonth: null,
  };

  availableTime: TimeInterface[] = [];
  availableEndTime: TimeInterface[] = [];

  // max amount of days allowed to book
  private maxDays = 30;

  // getters for various formGroups/controls data
  get startDateGroup(): FormGroup {
    return this.bookingForm.get('startDateGroup') as FormGroup;
  }

  get roomInfoGroup(): FormGroup {
    return this.bookingForm.get('roomInfoGroup') as FormGroup;
  }

  get endDateGroup(): FormGroup {
    return this.bookingForm.get('endDateGroup') as FormGroup;
  }

  get userDataGroup(): FormGroup {
    return this.bookingForm.get('userDataGroup') as FormGroup;
  }

  get roomCapacityGroup(): FormGroup {
    return this.roomInfoGroup.get('roomCapacityGroup') as FormGroup;
  }

  get userName(): string {
    return this.userDataGroup.get('name')?.value;
  }

  get userEmail(): string {
    return this.userDataGroup.get('email')?.value;
  }

  get chosenYear(): number {
    return this.startDateGroup.get('year')?.value;
  }

  get chosenMonth(): number {
    return this.startDateGroup.get('month')?.value;
  }

  get chosenDay(): number {
    return this.startDateGroup.get('day')?.value;
  }

  get chosenEndYear(): number {
    return this.endDateGroup.get('year')?.value;
  }

  get chosenEndMonth(): number {
    return this.endDateGroup.get('month')?.value;
  }

  get chosenEndDay(): number {
    return this.endDateGroup.get('day')?.value;
  }

  get chosenTime(): TimeInterface {
    return this.bookingForm.get('startTime')?.value;
  }

  get chosenEndTime(): TimeInterface {
    return this.bookingForm.get('endTime')?.value;
  }

  get roomInfo(): NewBookingStructureResponseInterface {
    return this.roomInfoGroup.get('roomInfo')?.value;
  }

  get roomCapacities(): RoomCapacityInterface[] {
    return this.roomCapacityGroup.get('roomCapacities')?.value;
  }

  get roomChosenCapacityId(): number {
    return this.roomCapacityGroup.get('roomChosenCapacityId')?.value;
  }

  constructor(
    private calendarService: CalendarService,
    private fb: FormBuilder,
    private apiService: BookingApiService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.mode = this.route.snapshot.data['mode'];
    this.endpoint += this.mode;
    this.bookingForm = this.fb.group({
      userDataGroup: this.fb.group({
        name: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
      }),
      startDateGroup: this.fb.group({
        year: '',
        month: '',
        day: '',
      }),
      endDateGroup: this.fb.group({
        year: '',
        month: '',
        day: '',
      }),
      roomInfoGroup: this.fb.group({
        roomInfo: '',
        roomCapacityGroup: this.fb.group({
          roomCapacities: [],
          roomChosenCapacityId: '',
        }),
      }),
      startTime: '',
      endTime: '',
    });
  }

  ngOnInit(): void {
    this.bookingForm.reset();
    this.populateData();
  }

  populateData() {
    let id = Number(this.route.snapshot.paramMap.get('id'));
    if (this.mode === 'edit') {
      if (isNaN(id)) {
        this.router.navigate(['booking/add']);
        return;
      }
      let result$ = this.apiService
        .getById<EditBookingResponseInterface>(this.endpoint, Number(id))
        .pipe(
          catchError((err) => {
            this.router.navigate(['booking/add']);
            return throwError(() => err);
          })
        );
      this.roomTypes$ = result$.pipe(map((response) => response.roomTypes));
      result$.pipe(map((response) => response)).subscribe((response) => {
        let booking = response.booking;

        this.bookingId = booking.id;

        this.userDataGroup.get('name')?.setValue(booking.customerName);
        this.userDataGroup.get('email')?.setValue(booking.customerEmail);

        const startDate = new Date(booking.startDate);
        const endDate = new Date(booking.endDate);

        // repopulate years
        this.repopulateDates();
        const matchingYear = this.startDates.availableYears.find(
          (y) => y === startDate.getFullYear()
        );
        this.startDateGroup.get('year')?.setValue(matchingYear);

        // repopulate months based on years
        this.repopulateDates(matchingYear);
        const matchingMonth = this.startDates.availableMonths.find(
          (m) => m === startDate.getMonth()
        );
        this.startDateGroup.get('month')?.setValue(matchingMonth);

        // repopulate days based on years and months
        this.repopulateDates(matchingYear, matchingMonth);
        const matchingDay = this.startDates.availableDays.find(
          (d) => d === startDate.getDate()
        );
        this.startDateGroup.get('day')?.setValue(matchingDay);

        // repopulate end years
        this.repopulateEndDates();
        const matchingEndYear = this.endDates.availableYears.find(
          (y) => y === endDate.getFullYear()
        );
        this.endDateGroup.get('year')?.setValue(matchingEndYear);

        // repopulate end months based on years
        this.repopulateEndDates(matchingYear);
        const matchingEndMonth = this.endDates.availableMonths.find(
          (m) => m === endDate.getMonth()
        );
        this.endDateGroup.get('month')?.setValue(matchingEndMonth);

        // repopulate end days based on years and months
        this.repopulateEndDates(matchingEndYear, matchingEndMonth);
        const matchingEndDay = this.endDates.availableDays.find(
          (d) => d === endDate.getDate()
        );
        this.endDateGroup.get('day')?.setValue(matchingEndDay);

        // converting HH:MM string minutes
        const [startHour, startMinute] = booking.startTime.split(':');
        const startTimeInMinutes = Number(startHour) * 60 + Number(startMinute);
        const [endHour, endMinute] = booking.endTime.split(':');
        const endTimeInMinutes = Number(endHour) * 60 + Number(endMinute);

        // repopulating time
        this.repopulateTime();
        const matchingStartTime = this.availableTime.find(
          (t) => t.timeInMinutes === startTimeInMinutes
        );
        this.bookingForm.get('startTime')?.setValue(matchingStartTime);
        this.repopulateEndTime();
        const matchingEndTime = this.availableEndTime.find(
          (t) => t.timeInMinutes === endTimeInMinutes
        );
        this.bookingForm.get('endTime')?.setValue(matchingEndTime);

        // repopulating roomtypes
        const matchingRoomType = response.roomTypes.find(
          (rt) => rt.roomType.id === response.roomType.id
        );
        this.roomInfoGroup.get('roomInfo')?.setValue(matchingRoomType);

        // repopulating room capacities
        this.configureRoomType();
        if (response.roomCapacity.id && this.hasRooms) {
          this.roomCapacityGroup
            .get('roomChosenCapacityId')
            ?.setValue(response.roomCapacity.id);
        }
      });
    } else {
      this.roomTypes$ = this.apiService
        .get<NewBookingStructureResponseInterface[]>(this.endpoint)
        .pipe(
          tap((types) => {
            if (types && types.length > 0) {
              this.roomInfoGroup.get('roomInfo')?.setValue(types[0]);
              this.configureRoomType();
            }
          })
        );
      this.repopulateDates();
      this.repopulateEndDates();
      this.repopulateTime();
    }
  }

  // gets month name from calendarService depending on month number -1
  getMonthNameByNumber(month: number): string {
    return this.calendarService.monthNames[month];
  }

  // submit form event handler
  onSubmit() {
    if (this.hasRooms) {
      if (!this.roomChosenCapacityId) {
        this.bookingForm.setErrors({ invalidForm: true });
      }
    }
    if (this.bookingForm.valid) {
      const formattedStartMinutes =
        this.chosenTime.time.getMinutes() > 9
          ? `${this.chosenTime.time.getMinutes()}`
          : `${this.chosenTime.time.getMinutes()}0`;
      const formattedEndMinutes =
        this.chosenEndTime.time.getMinutes() > 9
          ? `${this.chosenEndTime.time.getMinutes()}`
          : `${this.chosenEndTime.time.getMinutes()}0`;
      let data: AddBookingCommandInterface = {
        bookingId: this.bookingId || null,
        roomTypeId: this.roomInfo.roomType.id,
        roomCapacityId: Number(this.roomChosenCapacityId) || null,
        customerId: this.userId,
        customerName: this.userName,
        customerEmail: this.userEmail,
        startDate: `${this.chosenYear}-${this.chosenMonth + 1}-${
          this.chosenDay
        }`,
        endDate: `${this.chosenEndYear}-${this.chosenEndMonth + 1}-${
          this.chosenEndDay
        }`,
        startTime: `${this.chosenTime.time.getHours()}:${formattedStartMinutes}`,
        endTime: `${this.chosenEndTime.time.getHours()}:${formattedEndMinutes}`,
      };
      if (this.mode === 'edit') {
        this.apiService
          .put<AddBookingCommandInterface>(this.endpoint, data)
          .subscribe((response) => {
            console.log(response);
          });
      } else {
        this.apiService
          .post<AddBookingCommandInterface>(this.endpoint, data)
          .subscribe((response) => {
            console.log(response);
          });
      }
    }
  }

  // roomType change event handlers
  onRoomTypeChange() {
    this.roomCapacityGroup.get('roomChosenCapacityId')?.setValue('');
    this.configureRoomType();
  }

  // date/time change event handlers
  onYearChange() {
    this.repopulateDates(this.chosenYear);
    this.repopulateEndDates();
    this.repopulateTime();
  }

  onMonthChange() {
    this.repopulateDates(this.chosenYear, this.chosenMonth);
    this.repopulateEndDates();
    this.repopulateTime();
  }

  onDayChange() {
    this.repopulateEndDates();
    this.repopulateTime();
  }

  onEndYearChange() {
    this.repopulateEndDates(this.chosenEndYear);
  }

  onEndMonthChange() {
    this.repopulateEndDates(this.chosenEndYear, this.chosenEndMonth);
  }

  onTimeChange() {
    this.repopulateEndTime();
  }

  compareRoomTypes(
    a: NewBookingStructureResponseInterface,
    b: NewBookingStructureResponseInterface
  ): boolean {
    return a && b ? a.roomType.id === b.roomType.id : a === b;
  }

  // configures rules for room types, repopulates roomCapacities, repopulates end time/date if maxDays available for booking has changed
  // all room types with unique maxDays / types without rooms should be added here
  private configureRoomType() {
    const roomInfo = this.roomInfoGroup.get('roomInfo')
      ?.value as NewBookingStructureResponseInterface;
    if (roomInfo.roomType.type === WorkspaceTypes.OPENSPACE) {
      this.roomInfoGroup.get('roomCapacityGroup')?.patchValue({
        roomCapacities: '',
        roomChosenCapacityId: '',
      });
      this.hasRooms = false;
      let temp = this.maxDays;
      this.maxDays = 1;
      if (temp !== this.maxDays) {
        this.repopulateEndDates();
      }
    } else {
      this.roomCapacityGroup
        .get('roomCapacities')
        ?.setValue(this.roomInfo.roomCapacities);
      this.hasRooms = true;
      let temp = this.maxDays;
      this.maxDays = 30;
      if (temp !== this.maxDays) {
        this.repopulateEndDates();
      }
    }
  }

  // repopulates startDates arrays and changes currently chosen start year/month/day depending on which values were provided
  private repopulateDates(
    year: number | null = null,
    month: number | null = null
  ) {
    this.startDates.selectedYear = year;
    this.startDates.selectedMonth = month;
    this.startDates = this.calendarService.populateStartDates(
      this.startDates,
      this.numberOfYears
    );
    if (year === null) {
      this.startDateGroup
        .get('year')
        ?.setValue(this.startDates.availableYears[0]);
    }
    if (month === null) {
      this.startDateGroup
        .get('month')
        ?.setValue(this.startDates.availableMonths[0]);
    }
    this.startDateGroup.get('day')?.setValue(this.startDates.availableDays[0]);
  }

  // repopulates endDates arrays and changes currently chosen end year/month/day depending on which values were provided
  private repopulateEndDates(
    year: number | null = null,
    month: number | null = null
  ) {
    this.endDates.selectedYear = year;
    this.endDates.selectedMonth = month;
    this.endDates = this.calendarService.populateEndDates(
      this.endDates,
      this.chosenYear,
      this.chosenMonth,
      this.chosenDay,
      this.maxDays
    );
    if (year === null) {
      this.endDateGroup.get('year')?.setValue(this.endDates.availableYears[0]);
    }
    if (month === null) {
      this.endDateGroup
        .get('month')
        ?.setValue(this.endDates.availableMonths[0]);
    }
    this.endDateGroup.get('day')?.setValue(this.endDates.availableDays[0]);
  }

  // repopulates startTime arrays and changes currently chosen start time
  private repopulateStartTime() {
    this.availableTime = this.calendarService.populateTime(this.chosenDay);
    this.bookingForm.get('startTime')?.setValue(this.availableTime[0]);
  }

  // repopulates endTime arrays and changes currently chosen end time
  private repopulateEndTime() {
    this.availableEndTime = this.calendarService.populateTime(
      this.chosenDay,
      this.chosenTime.timeInMinutes
    );
    this.bookingForm.get('endTime')?.setValue(this.availableEndTime[0]);
  }

  private repopulateTime() {
    this.repopulateStartTime();
    this.repopulateEndTime();
  }
}
