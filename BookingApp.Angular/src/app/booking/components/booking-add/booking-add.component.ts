import { Component, OnInit } from '@angular/core';
import { CalendarService } from '../../services/calendar.service';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { TimeInterface } from '../../interfaces/calendar/time.interface';
import { DateSelectInterface } from '../../interfaces/calendar/date-select.interface';

@Component({
  selector: 'app-booking-add',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './booking-add.component.html',
  styleUrl: './booking-add.component.css',
})
export class BookingAddComponent implements OnInit {
  startDateForm: FormGroup;
  endDateForm: FormGroup;
  startTimeForm: FormGroup;
  endTimeForm: FormGroup;

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

  private lastMinuteFlag = false;

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

  get chosenTime(): TimeInterface {
    return this.startTimeForm.get('time')?.value;
  }

  get chosenEndTime(): TimeInterface {
    return this.endTimeForm.get('time')?.value;
  }

  constructor(private calendarService: CalendarService) {
    this.calendarService = calendarService;
    this.startDateForm = new FormGroup({
      year: new FormControl(),
      month: new FormControl(),
      day: new FormControl(),
    });
    this.endDateForm = new FormGroup({
      year: new FormControl(),
      month: new FormControl(),
      day: new FormControl(),
    });
    this.startTimeForm = new FormGroup({
      time: new FormControl(),
    });
    this.endTimeForm = new FormGroup({
      time: new FormControl(),
    });
  }

  ngOnInit(): void {
    this.repopulateDates();
    this.repopulateTime();
    if (this.chosenTime.timeInMinutes >= this.calendarService.lastMinuteOfDay) {
      this.lastMinuteFlag = true;
    }
    this.repopulateEndDates();
    this.repopulateEndTime();
  }

  getMonthNameByNumber(month: number): string {
    return this.calendarService.monthNames[month];
  }

  onYearChange() {
    this.repopulateDates(this.chosenYear);
    this.repopulateTime();
    this.repopulateEndDates();
    this.repopulateEndTime();
  }

  onMonthChange() {
    this.repopulateDates(this.chosenYear, this.chosenMonth);
    this.repopulateTime();
    this.repopulateEndDates();
    this.repopulateEndTime();
  }

  onDayChange() {
    this.repopulateTime();
    this.repopulateEndDates();
    this.repopulateEndTime();
  }

  onEndYearChange() {
    this.repopulateEndDates(this.chosenEndYear);
    this.repopulateEndTime();
  }

  onEndMonthChange() {
    this.repopulateEndDates(this.chosenEndYear, this.chosenEndMonth);
    this.repopulateEndTime();
  }

  onEndDayChange() {
    this.repopulateEndTime();
  }

  onTimeChange() {
    if (this.chosenTime.timeInMinutes >= this.calendarService.lastMinuteOfDay) {
      this.repopulateEndDates(this.chosenEndYear, this.chosenEndMonth);
      this.lastMinuteFlag = true;
    } else if (this.lastMinuteFlag) {
      this.repopulateEndDates(this.chosenEndYear, this.chosenEndMonth);
      this.lastMinuteFlag = false;
    }
    this.repopulateEndTime();
  }

  private repopulateDates(
    year: number | null = null,
    month: number | null = null
  ) {
    this.startDates.selectedYear = year;
    this.startDates.selectedMonth = month;
    this.startDates = this.calendarService.populateStartDates(this.startDates);
    if (year === null) {
      this.startDateForm.patchValue({
        year: this.startDates.availableYears[0],
      });
    }
    if (month === null) {
      this.startDateForm.patchValue({
        month: this.startDates.availableMonths[0],
      });
    }
    this.startDateForm.patchValue({
      day: this.startDates.availableDays[0],
    });
  }

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
      this.chosenTime.timeInMinutes,
      30
    );
    if (year === null) {
      this.endDateForm.patchValue({
        year: this.endDates.availableYears[0],
      });
    }
    if (month === null) {
      this.endDateForm.patchValue({
        month: this.endDates.availableMonths[0],
      });
    }
    this.endDateForm.patchValue({
      day: this.endDates.availableDays[0],
    });
  }

  private repopulateTime() {
    let isToday =
      this.chosenDay === this.calendarService.currentDay &&
      this.chosenMonth === this.calendarService.currentMonth &&
      this.chosenYear === this.calendarService.currentYear;
    this.availableTime = this.calendarService.populateTime(isToday);
    this.startTimeForm.patchValue({
      time: this.availableTime[0],
    });
  }

  private repopulateEndTime() {
    let isToday =
      this.chosenDay === this.chosenEndDay &&
      this.chosenMonth === this.chosenEndMonth &&
      this.chosenYear === this.chosenEndYear;
    this.availableEndTime = this.calendarService.populateTime(
      isToday,
      this.chosenTime.timeInMinutes
    );
    this.endTimeForm.patchValue({
      time: this.availableEndTime[0],
    });
  }
}
