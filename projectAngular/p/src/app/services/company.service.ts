import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Company } from "../classes/company";

@Injectable({
  providedIn: "root",
})

export class CompanyService {
  constructor(private http: HttpClient) { }
  getAllCompanies(): Observable<Company[]> {
    return this.http.get<Company[]>("https://localhost:7145/api/CompnyControllers")
  }
}

