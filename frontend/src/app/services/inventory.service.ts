import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  private apiUrl = `${environment.apiUrl}/inventory`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  getLowStock(): Observable<any> {
    return this.http.get(`${this.apiUrl}/low-stock`);
  }

  createOrder(data: any): Observable<any> {
    return this.http.post(`${environment.apiUrl}/orders`, data);
  }
}
