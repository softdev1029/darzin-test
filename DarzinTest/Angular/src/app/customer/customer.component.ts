import { Component, OnInit } from '@angular/core';
import CommonService from 'src/shared/common.service';
import CustomerModel from 'src/shared/CustomerModel';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  private customer: CustomerModel;

  constructor(private commonService: CommonService) {
    this.commonService.getCustomer().subscribe((customer) => {
      this.customer = customer
    });

  }

  ngOnInit() {
  }

}
