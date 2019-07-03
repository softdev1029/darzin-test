import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import ApiService from '../shared/api.service';
import { ProductsComponent } from './products/products.component';

@NgModule({
  declarations: [
    ProductsComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
  ],
  providers: [ApiService],
  bootstrap: [ProductsComponent]
})
export class AppModule { }
