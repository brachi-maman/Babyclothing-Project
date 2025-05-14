import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Customer } from "../classes/customer";

@Injectable({
    providedIn: "root",
})
export class CustomerService {
    constructor(private http: HttpClient) { }
    currentCustomer: Customer = new Customer()
    register(customer: Customer): Observable<Customer> {
        return this.http.post<Customer>("https://localhost:7145/api/Customer/addCustomer", customer)
    }

    login(object: object): Observable<Customer> {
        return this.http.post<Customer>("https://localhost:7145/api/Customer/login", object)
    }
}