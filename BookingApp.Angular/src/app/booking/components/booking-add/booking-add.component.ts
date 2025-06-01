import { Component, OnInit } from '@angular/core';
import { CalendarService } from '../../services/calendar.service';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { DateYearInterface } from '../../interfaces/date-year.interface';

@Component({
  selector: 'app-booking-add',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './booking-add.component.html',
  styleUrl: './booking-add.component.css',
})
export class BookingAddComponent implements OnInit {
  readonly monthNames = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December',
  ];
  calendarService!: CalendarService;

  startDateForm!: FormGroup;
  endDateForm!: FormGroup;

  availableYears: number[] = [];
  availableMonths: number[] = [];
  availableDays: number[] = [];
  availableEndYears: number[] = [];
  availableEndMonths: number[] = [];
  availableEndDays: number[] = [];

  availableEndDatesDictionary: { [year: number]: DateYearInterface } = [];

  get chosenYear(): number {
    return this.startDateForm.get('year')?.value;
  }

  get chosenMonth(): number {
    return this.startDateForm.get('month')?.value;
  }

  get chosenDay(): number {
    return this.startDateForm.get('day')?.value;
  }

  get chosenEndYear(): number {
    return this.endDateForm.get('year')?.value;
  }

  get chosenEndMonth(): number {
    return this.endDateForm.get('month')?.value;
  }

  get chosenEndDay(): number {
    return this.endDateForm.get('day')?.value;
  }

  constructor(calendarService: CalendarService) {
    this.calendarService = calendarService;
  }

  ngOnInit(): void {
    this.startDateForm = new FormGroup({
      year: new FormControl(this.calendarService.currentYear),
      month: new FormControl(this.calendarService.currentMonth),
      day: new FormControl(this.calendarService.currentDay),
    });
    this.endDateForm = new FormGroup({
      year: new FormControl(this.calendarService.currentYear),
      month: new FormControl(this.calendarService.currentMonth),
      day: new FormControl(this.calendarService.currentDay),
    });

    this.availableYears = this.calendarService.populateYears();
    this.availableMonths = this.calendarService.populateMonths(this.chosenYear);
    this.availableDays = this.calendarService.populateDays(
      this.chosenYear,
      this.chosenMonth
    );
    this.repopulateEndDates();
    this.loadAvailableEndYears();
  }

  // if start year changes load all available months/days + end years/months/days
  onYearChange(event: Event) {
    const element = event.target as HTMLSelectElement;
    const year = Number(element.value);
    this.availableMonths = this.calendarService.populateMonths(year);
    const month = this.availableMonths[0];
    this.availableDays = this.calendarService.populateDays(year, month);
    const day = this.availableDays[0];
    this.startDateForm.patchValue({
      month: month,
      day: day,
    });
    this.repopulateEndDates();
    this.loadAvailableEndYears();
  }

  // if start month changes load all available days + end years/months/days
  onMonthChange(event: Event) {
    const element = event.target as HTMLSelectElement;
    const month = Number(element.value);
    this.availableDays = this.calendarService.populateDays(
      this.chosenYear,
      month
    );
    const day = this.availableDays[0];
    this.startDateForm.patchValue({
      day: day,
    });
    this.repopulateEndDates();
    this.loadAvailableEndYears();
  }

  // if start month changes load all end years/months/days
  onDayChange() {
    this.repopulateEndDates();
    this.loadAvailableEndYears();
  }

  loadAvailableEndYears() {
    this.availableEndYears = Object.keys(this.availableEndDatesDictionary).map(
      (year) => Number(year)
    );
    this.endDateForm.patchValue({
      year: this.availableEndYears[0],
    });
    this.loadAvailableEndMonths();
  }

  loadAvailableEndMonths() {
    const selectedYear = this.chosenEndYear;
    this.availableEndMonths = Object.keys(
      this.availableEndDatesDictionary[selectedYear].months
    ).map((month) => Number(month));
    this.endDateForm.patchValue({
      month: this.availableEndMonths[0],
    });
    this.loadAvailableEndDays();
  }

  loadAvailableEndDays() {
    const selectedYear = this.endDateForm.get('year')?.value;
    const selectedMonth = this.endDateForm.get('month')?.value;

    this.availableEndDays =
      this.availableEndDatesDictionary[selectedYear].months[selectedMonth].days;

    this.endDateForm.patchValue({
      day: this.availableEndDays[0],
    });
  }

  onEndYearChange() {
    this.loadAvailableEndMonths();
    this.endDateForm.patchValue({
      month: this.availableEndMonths[0],
      day: this.availableEndDays[0],
    });
  }

  onEndMonthChange() {
    this.loadAvailableEndDays();
    this.endDateForm.patchValue({ day: this.availableEndDays[0] });
  }

  private repopulateEndDates() {
    this.availableEndDatesDictionary = this.calendarService.populateEndDates(
      this.chosenYear,
      this.chosenMonth,
      this.chosenDay,
      30
    );
  }
}
