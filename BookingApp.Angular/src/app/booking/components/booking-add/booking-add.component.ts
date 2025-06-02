import { Component, OnInit } from '@angular/core';
import { CalendarService } from '../../services/calendar.service';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { DateYearInterface } from '../../interfaces/calendar/date-year.interface';

@Component({
  selector: 'app-booking-add',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './booking-add.component.html',
  styleUrl: './booking-add.component.css',
})
export class BookingAddComponent implements OnInit {
  startDateForm!: FormGroup;
  endDateForm!: FormGroup;

  availableYears: number[] = [];
  availableMonths: number[] = [];
  availableDays: number[] = [];
  availableEndYears: number[] = [];
  availableEndMonths: number[] = [];
  availableEndDays: number[] = [];

  availableEndDatesDictionary: { [year: number]: DateYearInterface } = {};

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

  constructor(private calendarService: CalendarService) {
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

  onEndYearChange() {
    this.loadAvailableEndMonths();
  }

  onEndMonthChange() {
    this.loadAvailableEndDays();
  }

  getMonthName(month: number): string {
    return this.calendarService.monthNames[month];
  }

  // converting all available years from dictionary to array
  private loadAvailableEndYears() {
    this.availableEndYears = Object.keys(this.availableEndDatesDictionary).map(
      (year) => Number(year)
    );
    this.endDateForm.patchValue({
      year: this.availableEndYears[0],
    });
    this.loadAvailableEndMonths();
  }

  // converting all available months from dictionary to array
  private loadAvailableEndMonths() {
    this.availableEndMonths = Object.keys(
      this.availableEndDatesDictionary[this.chosenEndYear].months
    ).map((month) => Number(month));

    this.endDateForm.patchValue({
      month: this.availableEndMonths[0],
    });
    this.loadAvailableEndDays();
  }

  // converting all available days from dictionary to array
  private loadAvailableEndDays() {
    this.availableEndDays =
      this.availableEndDatesDictionary[this.chosenEndYear].months[
        this.chosenEndMonth
      ].days;

    this.endDateForm.patchValue({
      day: this.availableEndDays[0],
    });
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
