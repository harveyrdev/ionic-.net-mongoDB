import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { Product } from '../models/product';
import { Observable } from 'rxjs';
import { Order } from '../models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
 private apiUrl= `${environment.apiUrl}/api/orders`

  private _http= inject(HttpClient);

  
  getOrders(){
    return this._http.get(this.apiUrl);
  }

  crearOrden(productos: Product[]): Observable<Order> {
    return this._http.post<Order>(this.apiUrl, productos);
  }

  constructor() { }
}
