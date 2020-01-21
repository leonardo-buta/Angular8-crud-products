import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import Product from '../models/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private uri: string = environment.uri;

  constructor(private http: HttpClient) { }

  addProduct(product: Product) {
    product.price = Number(product.price);
    this.http.post(`${this.uri}/api/Product`, product)
      .subscribe(res => console.log('Done'));
  }

  editProduct(product: Product) {
    product.price = Number(product.price);
    this.http.put(`${this.uri}/api/Product/${product.id}`, product)
      .subscribe(res => console.log('Done'));
  }

  getProducts(page: number, name: string) {
    return this.http.get(`${this.uri}/api/Product?page=${page}&name=${name}`);
  }
}
