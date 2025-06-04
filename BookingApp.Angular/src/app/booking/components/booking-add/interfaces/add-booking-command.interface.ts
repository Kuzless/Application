export interface AddBookingCommandInterface {
  roomTypeId: number;
  roomCapacityId: number | null;
  customerName: string;
  customerEmail: string;
  startDate: string;
  endDate: string;
}
