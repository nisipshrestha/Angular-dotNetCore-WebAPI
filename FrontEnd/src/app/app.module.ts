import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http'

import { FormsModule } from "@angular/forms";
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { EmployeeComponent } from './employee/employee.component';
import { ProductComponent } from './product/product.component';
import { AppRoutingModule } from './/app-routing.module';
import { NavComponent } from './nav/nav.component';

const routes: Routes = [
  { path: '', component: CustomerComponent },
  { path: 'customer', component: CustomerComponent },
  { path: 'employee', component: EmployeeComponent },
  { path: 'product', component: ProductComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent, EmployeeComponent, ProductComponent, NavComponent
  ],
  imports: [
    HttpModule,
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes),
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
