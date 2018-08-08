import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor(private _http: Http) { }
  title='Employees';
  employees = [];
  getEmployees() {
    this._http.get('http://localhost:60839/api/Employee')
      .subscribe(data => { this.employees = data.json(); });
  }
  ngOnInit() {
    this.getEmployees();
  }
}