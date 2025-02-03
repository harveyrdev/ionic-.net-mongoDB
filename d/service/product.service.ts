import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrl= `${environment.apiUrl}/api/products`

  private _http= inject(HttpClient);

  
  getProducts(){
    return this._http.get(this.apiUrl);
  }

  constructor() { }
}
