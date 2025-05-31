import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CalendarService {
  readonly currentYear: number = new Date().getFullYear();
  readonly currentMonth: number = new Date().getMonth();
  readonly currentDay: number = new Date().getDate();
  constructor() {}

  populateYears(): number[] {
    let availableYears: number[] = [];
    for (let year = this.currentYear; year < this.currentYear + 5; year++) {
      availableYears.push(year);
    }
    return availableYears;
  }

  populateMonths(year: number): number[] {
    let availableMonths: number[] = [];
    let month = year === this.currentYear ? this.currentMonth : 0;
    for (; month <= 11; month++) {
      availableMonths.push(month);
    }
    return availableMonths;
  }

  populateDays(
    year: number,
    month: number,
    day: number | null = null,
    lastDay: number = new Date(year, month + 1, 0).getDate()
  ): number[] {
    let availableDays: number[] = [];
    if (day === null) {
      day =
        year === this.currentYear && month === this.currentMonth
          ? this.currentDay
          : 1;
    }
    for (; day <= lastDay; day++) {
      availableDays.push(day);
    }
    return availableDays;
  }
}
