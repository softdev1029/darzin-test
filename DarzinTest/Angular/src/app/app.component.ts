import { Component, OnInit } from '@angular/core';

import Product from '../shared/ProductModel';
import ApiService from '../shared/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit  {
  products: Array<Product>;

  constructor(private apiService: ApiService) {
  }

  ngOnInit() {
    this.apiService.getAll().subscribe(data => {
      this.products = data;
    });
  }
}
