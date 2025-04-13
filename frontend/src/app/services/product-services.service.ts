import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient} from '@angular/common/http';


export interface Product {
  id:number;
  name: string;
  description: string;
  price: number;
  quantityInStock: number;
  picture?: string;
  isDiscounted: boolean;
  discountPercentage: number;
  discountedPrice?: number; // ovo mi sami računamo
}

@Injectable({
  providedIn: 'root'
})
export class ProductServicesService {
  private apiUrl = 'http://localhost:5077/api/GetProductsByCategory';  // Endpoint za proizvode
  private router: any;

  constructor(private http: HttpClient) {}

  // Metoda za dobivanje proizvoda po kategoriji
  getProductsByCategory(categoryId: number): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apiUrl}/${categoryId}`);
  }

// Metoda za pretragu proizvoda
  searchProducts(query: string): Observable<Product[]> {
    const url = `http://localhost:5077/api/products/search`; // Endpoint koji si napravila u backendu
    return this.http.get<Product[]>(url, {
      params: {
        query: query
      }
    });
  }
  getProductById(id: number): Observable<Product> {
    return this.http.get<Product>(`http://localhost:5077/api/products/${id}`);
  }


}
