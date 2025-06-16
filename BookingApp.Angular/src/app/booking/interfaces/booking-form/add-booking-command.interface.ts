export interface AddBookingCommandInterface {
  bookingId: number | null;
  coworkingId: number;
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
