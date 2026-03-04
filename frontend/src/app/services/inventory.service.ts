import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Producto } from '../models/producto.model';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  private apiUrl = `${environment.apiUrl}/inventory`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Producto[]> {
    return this.http.get<Producto[]>(this.apiUrl);
  }

  getLowStock(): Observable<Producto[]> {
    return this.http.get<Producto[]>(`${this.apiUrl}/low-stock`);
  }

  createOrder(data: any): Observable<any> {
    return this.http.post(`${environment.apiUrl}/orders`, data);
  }
}
