import { Injectable } from '@angular/core';
import { TimeInterface } from '../interfaces/calendar/time.interface';
import { DateSelectInterface } from '../interfaces/calendar/date-select.interface';

@Injectable({
  providedIn: 'root',
})
export class CalendarService {
  // represent info on on today's date
  readonly currentYear: number;
  readonly currentMonth: number;
  readonly currentDay: number;
  readonly currentTimeInMinutes: number;

  // 23:30 in minutes. Used to indicate last available minute for day
  readonly lastMinuteOfDay = 1410;

  // 12:00 in minutes. Used to move from AM to PM
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

  // returns TimeInterface[] containing all available time.
  // takes boolean sameDay that indicates if startDate and endDate are the same day
  // startTime is used for populating availableEndTimes. It is basically floor that is not included if both startDate and endDate are the same day
  // endTime is used to set ceiling that is included for availableTime
  populateTime(
    sameDay: boolean,
    startTime: number | null = null,
    endTime: number | null = null
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

    endTime = endTime ? endTime : this.lastMinuteOfDay;

    for (; time <= endTime; time += 30) {
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
    return result;
  }

  // returns DateSelectInterface containing all available years, months for chosen year and days for chosen month
  // doesn't repopulate years if there's chosen year, months if there's chosen month. always repopulates days
  populateStartDates(
    data: DateSelectInterface,
    numberOfYears: number
  ): DateSelectInterface {
    if (data.selectedYear === null) {
      data.availableYears = [];
      for (
        let newYear = this.currentYear;
        newYear < this.currentYear + numberOfYears;
        newYear++
      ) {
        data.availableYears.push(newYear);
      }
      data.selectedYear = data.availableYears[0];
    }
    if (data.selectedMonth === null) {
      data.availableMonths = [];
      let newMonth =
        data.selectedYear === this.currentYear ? this.currentMonth : 0;
      for (; newMonth <= 11; newMonth++) {
        data.availableMonths.push(newMonth);
      }
      data.selectedMonth = data.availableMonths[0];
    }
    data.availableDays = [];
    let lastDay = new Date(
      data.selectedYear!,
      data.selectedMonth! + 1,
      0
    ).getDate();
    let day =
      (data.selectedYear === this.currentYear || !data.selectedYear) &&
      (data.selectedMonth === this.currentMonth || !data.selectedMonth)
        ? this.currentDay
        : 1;
    if (this.lastMinuteOfDay - 30 <= this.currentTimeInMinutes - 30) {
      day++;
    }
    for (; day <= lastDay; day++) {
      data.availableDays.push(day);
    }
    return data;
  }

  // returns DateSelectInterface containing all available end years, months for chosen year and days for chosen month
  // takes into account how many days since initial date have to be available
  // doesn't repopulate years if there's chosen year, months if there's chosen month. always repopulates days
  populateEndDates(
    data: DateSelectInterface,
    startYear: number,
    startMonth: number,
    startDay: number,
    startTime: number,
    maxDays: number
  ): DateSelectInterface {
    if (
      (data.selectedYear === startYear || !data.selectedYear) &&
      (data.selectedMonth === startMonth || !data.selectedMonth) &&
      startTime >= this.lastMinuteOfDay
    ) {
      startDay++;
    }
    let startDate = new Date(startYear, startMonth, startDay);
    const endDate = new Date(startDate);
    endDate.setDate(startDate.getDate() + maxDays);
    let newStartDate: Date;
    let hasYears = false;
    let hasMonths = false;
    if (data.selectedYear === null) {
      data = {
        selectedYear: startYear,
        selectedMonth: startMonth,
        availableYears: [],
        availableMonths: [],
        availableDays: [],
      };
      newStartDate = new Date(startDate);
    } else if (data.selectedMonth === null) {
      data.availableMonths = [];
      data.availableDays = [];
      if (data.selectedYear === startYear) {
        data.selectedMonth = startMonth;
        newStartDate = new Date(data.selectedYear, startMonth, startDay);
      } else {
        data.selectedMonth = 0;
        newStartDate = new Date(data.selectedYear, 0, 1);
      }
      hasYears = true;
    } else {
      data.availableDays = [];
      if (
        data.selectedYear === startYear &&
        data.selectedMonth === startMonth
      ) {
        newStartDate = new Date(
          data.selectedYear,
          data.selectedMonth,
          startDay
        );
      } else {
        newStartDate = new Date(data.selectedYear, data.selectedMonth, 1);
      }
      hasYears = true;
      hasMonths = true;
    }

    if (!hasYears) {
      let year = startYear;
      for (; year <= endDate.getFullYear(); year++) {
        data.availableYears.push(year);
      }
    }
    if (!hasMonths) {
      let month = data.selectedYear === startYear ? startMonth : 0;
      if (endDate.getFullYear() !== data.selectedYear) {
        for (; month <= 11; month++) {
          data.availableMonths.push(month);
        }
      } else {
        for (; month <= endDate.getMonth(); month++) {
          data.availableMonths.push(month);
        }
      }
    }

    let yearTracker = data.selectedYear;
    let monthTracker = data.selectedMonth;

    while (
      yearTracker == data.selectedYear &&
      monthTracker == data.selectedMonth
    ) {
      if (newStartDate > endDate) {
        break;
      }
      data.availableDays.push(newStartDate.getDate());
      newStartDate.setDate(newStartDate.getDate() + 1);
      yearTracker = newStartDate.getFullYear();
      monthTracker = newStartDate.getMonth();
    }
    return data;
  }
}
