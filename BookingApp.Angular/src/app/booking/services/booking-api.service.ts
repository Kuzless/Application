import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BookingApiService {
  private baseUrl = environment.baseUrl;
  private httpClient!: HttpClient;

  constructor(httpclient: HttpClient) {
    this.httpClient = httpclient;
  }

  getByEmail<T>(endpoint: string, email: string): Observable<T> {
    return this.httpClient.get<T>(`${this.baseUrl}/${endpoint}/${email}`);
  }
}
