export interface OperationResult<T> {
  isSuccess: boolean;
  message: string;
  errorCode: number;
  data: T | null;
}
