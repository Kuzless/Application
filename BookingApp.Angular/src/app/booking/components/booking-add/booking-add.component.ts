import { Component, OnInit } from '@angular/core';
import { CalendarService } from '../../services/calendar.service';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

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

  availableYears: number[] = [];
  availableMonths: number[] = [];
  availableDays: number[] = [];

  get chosenYear(): number {
    return this.startDateForm.get('year')?.value;
  }

  get chosenMonth(): number {
    return this.startDateForm.get('month')?.value;
  }

  get chosenDay(): number {
    return this.startDateForm.get('day')?.value;
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

    this.availableYears = this.calendarService.populateYears();
    this.availableMonths = this.calendarService.populateMonths(this.chosenYear);
    this.availableDays = this.calendarService.populateDays(
      this.chosenYear,
      this.chosenMonth
    );
  }

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
  }

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
  }
}
