import { Injectable } from '@angular/core';
import { DateYearInterface } from '../interfaces/calendar/date-year.interface';
import { DateMonthInterface } from '../interfaces/calendar/date-month.interface';
import { TimeInterface } from '../interfaces/calendar/time.interface';
import { DateSelectInterface } from '../interfaces/calendar/date-select.interface';

@Injectable({
  providedIn: 'root',
})
export class CalendarService {
  readonly currentYear: number;
  readonly currentMonth: number;
  readonly currentDay: number;
  readonly currentTimeInMinutes: number;
  readonly lastMinuteOfDay = 1410;
  readonly firstMinuteOfSecondHalf = 720;

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

  constructor() {
    const date = new Date();
    this.currentYear = date.getFullYear();
    this.currentMonth = date.getMonth();
    this.currentDay = date.getDate();
    this.currentTimeInMinutes = date.getHours() * 60 + date.getMinutes();
  }

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

  populateTime(
    sameDay: boolean,
    startTime: number | null = null
  ): TimeInterface[] {
    let result: TimeInterface[] = [];
    let time = 0;
    if (sameDay) {
      if (startTime === null) {
        let temp = this.currentTimeInMinutes % 30;
        time = this.currentTimeInMinutes - temp;
        if (temp !== 0) {
          time += 30;
        }
      } else {
        time = startTime + 30;
        let temp = time % 30;
        time -= temp;
        if (temp !== 0) {
          time += 30;
        }
      }
    }

    for (; time <= this.lastMinuteOfDay; time += 30) {
      let hours = Math.floor(time / 60) % 12;
      let minutes = time % 60;
      if (hours === 0) hours = 12;
      let stamp = time < this.firstMinuteOfSecondHalf ? 'AM' : 'PM';
      let additionalZero = minutes === 0 ? '0' : '';
      result.push({
        hours: Math.floor(time / 60),
        minutes: time % 60,
        timeInMinutes: time,
        formattedTime: `${hours}:${minutes}${additionalZero} ${stamp}`,
      });
    }
    for (let time of result) {
      console.log(
        `Stamp: ${time.formattedTime}. Time: ${time.hours}:${time.minutes}`
      );
    }
    return result;
  }

  populateDates(
    data: DateSelectInterface,
    year: number | null = null,
    month: number | null = null
  ): DateSelectInterface {
    if (year === null) {
      data = { availableYears: [], availableMonths: [], availableDays: [] };
      for (
        let newYear = this.currentYear;
        newYear < this.currentYear + 5;
        newYear++
      ) {
        data.availableYears.push(newYear);
      }
    }
    if (month === null) {
      data.availableMonths = [];
      data.availableDays = [];
      let newMonth = year === this.currentYear ? this.currentMonth : 0;
      for (; newMonth <= 11; newMonth++) {
        data.availableMonths.push(newMonth);
      }
    }
    data.availableDays = [];
    let lastDay = new Date(year!, month! + 1, 0).getDate();
    let day =
      (year === this.currentYear || !year) &&
      (month === this.currentMonth || !month)
        ? this.currentDay
        : 1;
    for (; day <= lastDay; day++) {
      data.availableDays.push(day);
    }
    return data;
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
