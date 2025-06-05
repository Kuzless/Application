export interface AddBookingCommandInterface {
  roomTypeId: number;
  roomCapacityId: number | null;
  customerId: string;
  customerName: string;
  customerEmail: string;
  startDate: string;
  endDate: string;
  startTime: string;
  endTime: string;
}
