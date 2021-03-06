import { Component, OnInit } from '@angular/core';
import CommonService from 'src/shared/common.service';
import CustomerModel from 'src/shared/CustomerModel';
import ApiService from 'src/shared/api.service';
import ProductModel from 'src/shared/ProductModel';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  private customer: CustomerModel;
  private products: Array<ProductModel>;
  private purchases: Array<ProductModel> = new Array<ProductModel>();
  private selectedProduct: number;

  constructor(
    private apiService: ApiService,
    private commonService: CommonService
  ) {
    this.commonService.getCustomer().subscribe((customer) => {
      this.customer = customer
      this.apiService.getPurchases(this.customer).subscribe(data => {
        this.purchases = data;
      });
    });

  }

  ngOnInit() {
    this.apiService.getProducts().subscribe(data => {
      this.products = data;
    });
  }

  onChange(index, data, i, type) {
    console.log(index);
  }
  onPurchase() {
    this.apiService.purchase(this.customer, this.products[this.selectedProduct]).subscribe(data => {
      //  this.purchases = data;
      this.purchases.push(this.products[this.selectedProduct]);
    });
  }
}
