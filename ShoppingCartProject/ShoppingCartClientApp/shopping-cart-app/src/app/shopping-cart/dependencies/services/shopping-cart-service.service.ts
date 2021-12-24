import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product';
import { ProductCategory } from '../models/productCategory';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartServiceService {
  apiUrl: string;

  constructor(private http: HttpClient) { 
    this.apiUrl = environment.BaseUrl;
  }

  //Get all productCategories method.
  getAllProductCategories(): Observable<ProductCategory[]>{
    return this.http.get<ProductCategory[]>(this.apiUrl + "products");
  }

  getAllProductsForCategory(id): Observable<Product[]>{
    return this.http.get<Product[]>(this.apiUrl + "products/" + "categoryProducts");
  }

}
