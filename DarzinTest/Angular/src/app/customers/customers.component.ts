import { Component, OnInit } from '@angular/core';

import Customer from '../../shared/CustomerModel';
import ApiService from '../../shared/api.service';
import CommonService from 'src/shared/common.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit  {
  customers: Array<Customer>;

  constructor(
    private apiService: ApiService,
    private commonService: CommonService) {
  }

  ngOnInit() {
    this.apiService.getCustomers().subscribe(data => {
      this.customers = data;
    });
  }

  protected onClick(customer: Customer) : void {
    this.commonService.setCustomer(customer);
  }

  onAdd(event: Event) {
    var customer: Customer = {
      id: 10,
      name: "Chris" + new Date().valueOf().toString(),
      description: "New"
    }
    this.apiService.addCustomer(customer).subscribe(customer => {
      this.customers.push(customer);
    }
    )
  }
}
