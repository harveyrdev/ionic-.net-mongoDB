import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private apiUrl = `${environment.apiUrl}/api/Product`;

  private _http = inject(HttpClient);

  getProducts(): Observable<any> {
    return this._http.get(this.apiUrl);
  }

  constructor() {}
}
