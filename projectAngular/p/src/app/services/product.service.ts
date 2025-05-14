import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Product } from "../classes/product";

@Injectable({
  providedIn: "root",
})

export class ProductService {
  constructor(private http: HttpClient) { }

  getAllProduct(): Observable<Product[]> {
    return this.http.get<Product[]>("https://localhost:7145/api/Product");
  }
  getByFilters(object: object): Observable<Product[]> {
    return this.http.post<Product[]>("https://localhost:7145/api/Product/getBySFilters", object);
  }

  getAllNewsProduct(): Observable<Product[]> {
    return this.http.get<Product[]>("https://localhost:7145/api/Product/news");
  }
}

