import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Product } from "../classes/product";
import { Category } from "../classes/category";

@Injectable({
  providedIn: "root",
})

export class CategoryService {
  constructor(private http: HttpClient) { }
  getAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>("https://localhost:7145/api/CategoryControllers")
  }
}

