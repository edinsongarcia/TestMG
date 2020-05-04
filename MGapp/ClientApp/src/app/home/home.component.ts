import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public employees: Employees[];

  constructor(private http: HttpClient) { }

  getEmployees(id: number) {
    const url = id ? `api/employees/${id}` : 'api/employees';
    this.http.get<Employees[]>(url).subscribe(result => {
      this.employees = result;
    }, error => console.error(error));
  }
}

interface Employees {
  id: number;
  name: string;
  contractTypeName: string;
  roleId: number;
  roleName: string;
  roleDescription: number;
  hourlySalary: number;
  monthlySalary: number;
  annualSalary: number;
}
