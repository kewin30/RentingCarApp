import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { Cars } from '../_models/cars';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  baseUrl = environment.apiUrl;
  cars: Cars[] = [];
  constructor(private http: HttpClient) { }

  getCars(): Observable<Cars[]> {
    return this.http.get<Cars[]>(this.baseUrl + "Member");
  }

  

  reserveCars(vin: string): Observable<Cars> {
    const url = `${this.baseUrl}Member/${vin}`;
  
    return this.http.put<Cars>(url, null);
  }
}
