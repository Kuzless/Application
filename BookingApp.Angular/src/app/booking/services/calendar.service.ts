import { Injectable } from '@angular/core';
import { DateYearInterface } from '../interfaces/calendar/date-year.interface';
import { DateMonthInterface } from '../interfaces/calendar/date-month.interface';

@Injectable({
  providedIn: 'root',
})
export class CalendarService {
  readonly currentYear: number = new Date().getFullYear();
  readonly currentMonth: number = new Date().getMonth();
  readonly currentDay: number = new Date().getDate();

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

  populateEndDates(
    year: number,
    month: number,
    day: number,
    maxDays: number
  ): { [year: number]: DateYearInterface } {
    const startDate = new Date(year, month, day);
    const endDate = new Date(startDate);
    endDate.setDate(startDate.getDate() + maxDays);
    let currentDate = new Date(startDate);
    let result: { [year: number]: DateYearInterface } = {};

    // Creating initial dates before loop
    let monthInterface: DateMonthInterface = {
      currentYear: year,
      currentMonth: month,
      days: [],
    };
    let dateInterface: DateYearInterface = {
      currentYear: year,
      months: { [monthInterface.currentMonth]: monthInterface },
    };

    let trackingYear = currentDate.getFullYear();
    let trackingMonth = currentDate.getMonth();

    while (currentDate <= endDate) {
      const currentDay = currentDate.getDate();
      const currentMonth = currentDate.getMonth();
      const currentYear = currentDate.getFullYear();

      // if new year, push copy of old year to array, create new year with 1st month assigned. Reset trackers
      if (trackingYear != currentYear) {
        result[trackingYear] = this.getDateInterfaceCopy(dateInterface);
        trackingYear = currentYear;
        trackingMonth = currentMonth;
        monthInterface = {
          currentYear: currentYear,
          currentMonth: currentMonth,
          days: [],
        };
        dateInterface = {
          currentYear: currentYear,
          months: { [currentMonth]: monthInterface },
        };
      }
      // if new month, push copy of old month to array, create new month. Reset trackers
      if (trackingMonth != currentMonth) {
        dateInterface.months[trackingMonth] =
          this.getMonthInterfaceCopy(monthInterface);
        trackingMonth = currentMonth;
        monthInterface = {
          currentYear: currentYear,
          currentMonth: currentMonth,
          days: [],
        };
        dateInterface.months[currentMonth] = monthInterface;
      }

      monthInterface.days.push(currentDay);
      currentDate.setDate(currentDate.getDate() + 1);
    }
    result[trackingYear] = this.getDateInterfaceCopy(dateInterface);
    return result;
  }

  private getDateInterfaceCopy(date: DateYearInterface): DateYearInterface {
    let newDateInterface: DateYearInterface = {
      currentYear: date.currentYear,
      months: {},
    };
    for (let [key, data] of Object.entries(date.months)) {
      let month = Number(key);
      let newMonthInterface: DateMonthInterface = {
        currentYear: date.currentYear,
        currentMonth: data.currentMonth,
        days: [...data.days],
      };
      newDateInterface.months[month] = newMonthInterface;
    }
    return newDateInterface;
  }

  private getMonthInterfaceCopy(month: DateMonthInterface): DateMonthInterface {
    let newMonthInterface: DateMonthInterface = {
      currentYear: month.currentYear,
      currentMonth: month.currentMonth,
      days: [...month.days],
    };
    return newMonthInterface;
  }
}
