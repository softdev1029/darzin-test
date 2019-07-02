import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import Product from './ProductModel';

@Injectable()
export default class ApiService {
  public API = 'http://localhost:8089/api';
  public PRODUCTS_ENDPOINT = `${this.API}/products`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Array<Product>> {
    return this.http.get<Array<Product>>(this.PRODUCTS_ENDPOINT);
  }
}
