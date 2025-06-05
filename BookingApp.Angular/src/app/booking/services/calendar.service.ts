import { Injectable } from '@angular/core';
import { TimeInterface } from '../interfaces/calendar/time.interface';
import { DateSelectInterface } from '../interfaces/calendar/date-select.interface';

@Injectable({
  providedIn: 'root',
})
export class CalendarService {
  // represent info on on today's date
  firstAvailableYear!: number;
  firstAvailableMonth!: number;
  firstAvailableDay!: number;
  firstAvailableTimeInMinutes!: number;

  // 24:00 in minutes. Used to indicate last available minute for day
  readonly lastMinuteOfDay = 1440;

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
    this.setInitialData();
  }

  // returns TimeInterface[] containing all available time.
  // startTime sets floor value that is not included
  // if startTime isn't specified - last minute option will not be added to array
  // this prohibits setting startTime to last minute and leaves space for endTime
  populateTime(
    chosenDay: number,
    startTime: number | null = null
  ): TimeInterface[] {
    let result: TimeInterface[] = [];
    let time = 0;
    let lastMinute = this.lastMinuteOfDay;
    if (chosenDay === this.firstAvailableDay) {
      if (!startTime) {
        time = this.firstAvailableTimeInMinutes;
        lastMinute = this.lastMinuteOfDay - 30;
      }
    }
    if (startTime !== null) {
      time = startTime + 30;
      let temp = time % 30;
      time -= temp;
      if (temp !== 0) {
        time += 30;
      }
    }
    for (; time <= lastMinute; time += 30) {
      let hours = Math.floor(time / 60) % 12;
      let minutes = time % 60;
      if (hours === 0) hours = 12;
      let stamp =
        time < this.firstMinuteOfSecondHalf || time === this.lastMinuteOfDay
          ? 'AM'
          : 'PM';
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
        let newYear = this.firstAvailableYear;
        newYear < this.firstAvailableYear + numberOfYears;
        newYear++
      ) {
        data.availableYears.push(newYear);
      }
      data.selectedYear = data.availableYears[0];
    }
    if (data.selectedMonth === null) {
      data.availableMonths = [];
      let newMonth =
        data.selectedYear === this.firstAvailableYear
          ? this.firstAvailableMonth
          : 0;
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
      (data.selectedYear === this.firstAvailableYear || !data.selectedYear) &&
      (data.selectedMonth === this.firstAvailableMonth || !data.selectedMonth)
        ? this.firstAvailableDay
        : 1;
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
    maxDays: number
  ): DateSelectInterface {
    let startDate = new Date(startYear, startMonth, startDay);
    const endDate = new Date(startDate);
    endDate.setDate(startDate.getDate() + maxDays - 1);
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

  private setInitialData() {
    const today = new Date();
    let curTime = today.getHours() * 60 + today.getMinutes();
    let temp = curTime % 30;
    this.firstAvailableTimeInMinutes = curTime - temp;
    if (temp !== 0) {
      this.firstAvailableTimeInMinutes += 30;
    }
    if (this.firstAvailableTimeInMinutes >= this.lastMinuteOfDay - 30) {
      today.setDate(today.getDate() + 1);
      this.firstAvailableTimeInMinutes = 0;
    }
    this.firstAvailableYear = today.getFullYear();
    this.firstAvailableMonth = today.getMonth();
    this.firstAvailableDay = today.getDate();
  }
}
