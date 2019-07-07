import { Component, OnInit } from '@angular/core';

import Product from '../../shared/ProductModel';
import ApiService from '../../shared/api.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit  {
  products: Array<Product>;

  constructor(private apiService: ApiService) {
  }

  ngOnInit() {
    this.apiService.getProducts().subscribe(data => {
      this.products = data;
    });
  }

  onAdd(event: Event) {
    var product: Product = {
      id: 10,
      description: "New " + new Date().valueOf().toString(),
      price: 10
    }
    this.apiService.addProduct(product).subscribe(product => {
      this.products.push(product);
    }
    )
  }
}
