import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import ApiService from '../shared/api.service';
import { AppRoutingModule }     from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomerComponent } from './customer/customer.component';
import CommonService from 'src/shared/common.service';

@NgModule({
  declarations: [
    // AppRoutingModule,
    AppComponent,
    ProductsComponent,
    CustomersComponent,
    CustomerComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
  ],
  providers: [ApiService, CommonService],
  bootstrap: [AppComponent]
})
export class AppModule { }
