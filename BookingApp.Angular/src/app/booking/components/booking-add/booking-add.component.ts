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

  private isToday: boolean = true;

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
    this.startDateForm.patchValue({
      year: this.startDates.availableYears[0],
      month: this.startDates.availableMonths[0],
      day: this.startDates.availableDays[0],
    });
    this.repopulateTime();
    this.startTimeForm.patchValue({
      time: this.availableTime[0],
    });
    this.repopulateEndDates();
    this.endDateForm.patchValue({
      year: this.startDates.availableYears[0],
      month: this.startDates.availableMonths[0],
      day: this.startDates.availableDays[0],
    });
    this.repopulateEndTime();
    this.endTimeForm.patchValue({
      time: this.availableEndTime[0],
    });
  }

  onYearChange() {
    this.repopulateDates(this.chosenYear);
    this.startDateForm.patchValue({
      month: this.startDates.availableMonths[0],
      day: this.startDates.availableDays[0],
    });
    if (
      this.isDayChangedFromToday(
        this.chosenYear,
        this.chosenMonth,
        this.chosenDay
      )
    ) {
      this.repopulateTime();
      this.startTimeForm.patchValue({
        time: this.availableTime[0],
      });
    }
    this.repopulateEndDates();
    this.endDateForm.patchValue({
      year: this.endDates.availableYears[0],
      month: this.endDates.availableMonths[0],
      day: this.endDates.availableDays[0],
    });
    this.repopulateEndTime();
    this.endTimeForm.patchValue({
      time: this.availableEndTime[0],
    });
  }

  onMonthChange() {
    this.repopulateDates(this.chosenYear, this.chosenMonth);
    this.startDateForm.patchValue({
      day: this.startDates.availableDays[0],
    });
    if (
      this.isDayChangedFromToday(
        this.chosenYear,
        this.chosenMonth,
        this.chosenDay
      )
    ) {
      this.repopulateTime();
      this.startTimeForm.patchValue({
        time: this.availableTime[0],
      });
    }
    this.repopulateEndDates();
    this.endDateForm.patchValue({
      year: this.endDates.availableYears[0],
      month: this.endDates.availableMonths[0],
      day: this.endDates.availableDays[0],
    });
    this.repopulateEndTime();
    this.endTimeForm.patchValue({
      time: this.availableEndTime[0],
    });
  }

  onDayChange() {
    if (
      this.isDayChangedFromToday(
        this.chosenYear,
        this.chosenMonth,
        this.chosenDay
      )
    ) {
      this.repopulateTime();
      this.startTimeForm.patchValue({
        time: this.availableTime[0],
      });
    }
    this.repopulateEndDates();
    this.endDateForm.patchValue({
      year: this.endDates.availableYears[0],
      month: this.endDates.availableMonths[0],
      day: this.endDates.availableDays[0],
    });
    this.repopulateEndTime();
    this.endTimeForm.patchValue({
      time: this.availableEndTime[0],
    });
  }

  onEndYearChange() {
    this.repopulateEndDates(this.chosenEndYear);
    this.endDateForm.patchValue({
      month: this.endDates.availableMonths[0],
      day: this.endDates.availableDays[0],
    });
    if (
      this.isDayChangedFromToday(
        this.chosenEndYear,
        this.chosenEndMonth,
        this.chosenEndDay
      )
    ) {
      this.repopulateEndTime();
      this.endTimeForm.patchValue({
        time: this.availableEndTime[0],
      });
    }
  }

  onEndMonthChange() {
    this.repopulateEndDates(this.chosenEndYear, this.chosenEndMonth);
    this.endDateForm.patchValue({
      day: this.endDates.availableDays[0],
    });
    if (
      this.isDayChangedFromToday(
        this.chosenEndYear,
        this.chosenEndMonth,
        this.chosenEndDay
      )
    ) {
      this.repopulateEndTime();
      this.endTimeForm.patchValue({
        time: this.availableEndTime[0],
      });
    }
  }

  onEndDayChange() {
    if (
      this.isDayChangedFromToday(
        this.chosenEndYear,
        this.chosenEndMonth,
        this.chosenEndDay
      )
    ) {
      this.repopulateEndTime();
      this.endTimeForm.patchValue({
        time: this.availableEndTime[0],
      });
    }
  }

  getMonthName(month: number): string {
    return this.calendarService.monthNames[month];
  }

  onTimeChange() {
    this.repopulateEndTime();
    this.endTimeForm.patchValue({
      time: this.availableEndTime[0],
    });
  }

  private isDayChangedFromToday(
    year: number,
    month: number,
    day: number
  ): boolean {
    let today =
      day === this.calendarService.currentDay &&
      month === this.calendarService.currentMonth &&
      year === this.calendarService.currentYear;
    if (this.isToday) {
      if (today) {
        return false;
      }
      this.isToday = false;
      return true;
    } else {
      if (today) {
        this.isToday = true;
        return true;
      }
      return false;
    }
  }

  private get isStartDateSameAsEndDate(): boolean {
    return (
      this.chosenDay === this.chosenEndDay &&
      this.chosenMonth === this.chosenEndMonth &&
      this.chosenYear === this.chosenEndYear
    );
  }

  private repopulateDates(
    year: number | null = null,
    month: number | null = null
  ) {
    this.startDates.selectedYear = year;
    this.startDates.selectedMonth = month;
    this.startDates = this.calendarService.populateStartDates(this.startDates);
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
      30
    );
  }

  private repopulateTime() {
    this.availableTime = this.calendarService.populateTime(this.isToday);
  }

  private repopulateEndTime() {
    this.availableEndTime = this.calendarService.populateTime(
      this.isStartDateSameAsEndDate,
      this.chosenTime.timeInMinutes
    );
  }
}
