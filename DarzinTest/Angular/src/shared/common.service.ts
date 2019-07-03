import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

import Customer from './CustomerModel';

@Injectable()
export default class CommonService {
  private customer: Subject<Customer> = new Subject();

  public getCustomer(): Observable<Customer> {
      return this.customer.asObservable();
  }

  public setCustomer(customer: Customer) : void {
      this.customer.next(customer);
  }
}
