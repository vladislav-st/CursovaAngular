import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/Models/api.response';
import { ProductModel } from 'src/app/Models/ProductModel';

@Injectable({
  providedIn: 'root'
})
export class ProductManagerService {

  baseUrl = '/api/Admin';
  constructor(private http: HttpClient) { }

  getAllProducts() {
    return this.http.get(this.baseUrl);
  }

  removeProduct(id: number) {
    return this.http.get(this.baseUrl + `/RemoveProduct/${id}`, { headers: { 'Content-Type': 'application/json' } });
  }

  addProduct(model: ProductModel): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(this.baseUrl, model);
  }

  editProduct(id: number, model: ProductModel): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(this.baseUrl + '//' + id, model);
  }
}