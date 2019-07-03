import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import Product from './ProductModel';
import Customer from './CustomerModel';

@Injectable()
export default class ApiService {
  public API = 'http://localhost:8089/api';
  public PRODUCTS_ENDPOINT = `${this.API}/products`;
  public CUSTOMERS_ENDPOINT = `${this.API}/customers`;

  constructor(private http: HttpClient) { }

  // products
  getProducts(): Observable<Array<Product>> {
    return this.http.get<Array<Product>>(this.PRODUCTS_ENDPOINT);
  }

  addProduct(product: Product): Observable<any> {
    return this.http.post<Product>(this.PRODUCTS_ENDPOINT, product);
  }

  // customers
  getCustomers(): Observable<Array<Customer>> {
    return this.http.get<Array<Customer>>(this.CUSTOMERS_ENDPOINT);
  }

  addCustomer(customer: Customer): Observable<any> {
    return this.http.post<Customer>(this.CUSTOMERS_ENDPOINT, customer);
  }
}
