import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  constructor(private http: Http) {
  }
  customers = [];
  title='Customers';

  getCustomers() {
    this.http.get('http://localhost:60839/api/Customer')
      .subscribe(res => { this.customers = res.json(); });
  }
  ngOnInit() {
    this.getCustomers();
  }
}

