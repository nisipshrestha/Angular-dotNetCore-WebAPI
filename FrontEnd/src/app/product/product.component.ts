import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(private _http: Http) { }
  title='Products';
  products = [];
  getProducts() {
    this._http.get('http://localhost:60839/api/product')
      .subscribe(res => this.products = res.json());
  }
  ngOnInit() {
    this.getProducts();
  }
}