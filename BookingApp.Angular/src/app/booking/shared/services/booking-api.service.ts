import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment.development';
import { Observable, map } from 'rxjs';
import { OperationResult } from '../../../shared/interfaces/operation-result.interface';

@Injectable({
  providedIn: 'root',
})
export class BookingApiService {
  private baseUrl = environment.baseUrl;

  constructor(private httpClient: HttpClient) {}

  getByUserId<T>(endpoint: string, userId: string): Observable<T> {
    return this.httpClient
      .get<OperationResult<T>>(`${this.baseUrl}/${endpoint}/${userId}`)
      .pipe(
        map((result) => {
          if (result.isSuccess) {
            return result.data!;
          } else {
            throw new Error(result.message);
          }
        })
      );
  }

  get<T>(endpoint: string): Observable<T> {
    return this.httpClient
      .get<OperationResult<T>>(`${this.baseUrl}/${endpoint}`)
      .pipe(
        map((result) => {
          if (result.isSuccess) {
            return result.data!;
          } else {
            throw new Error(result.message);
          }
        })
      );
  }

  post<T>(endpoint: string, body: T): Observable<boolean> {
    return this.httpClient
      .post<OperationResult<T>>(`${this.baseUrl}/${endpoint}`, body)
      .pipe(
        map((result) => {
          if (result.isSuccess) {
            return result.isSuccess;
          } else {
            throw new Error(result.message);
          }
        })
      );
  }

  delete(endpoint: string, id: number): Observable<boolean> {
    return this.httpClient
      .delete<OperationResult<any>>(`${this.baseUrl}/${endpoint}/${id}`)
      .pipe(
        map((result) => {
          if (result.isSuccess) {
            return result.isSuccess;
          } else {
            throw new Error(result.message);
          }
        })
      );
  }
}
