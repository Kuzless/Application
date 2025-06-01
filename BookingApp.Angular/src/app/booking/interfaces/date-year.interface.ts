import { DateMonthInterface } from './date-month.interface';

export interface DateYearInterface {
  currentYear: number;
  months: { [month: number]: DateMonthInterface };
}
