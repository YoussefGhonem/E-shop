import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from 'src/app/_Models/product';
@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseURL = environment.apiUrl + 'product/';
  baseURL2 = environment.apiUrl + 'Photos/';
  constructor(private http: HttpClient) { }

  getProduct(id): Observable<Product> {
    return this.http.get<Product>(this.baseURL + id);
  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseURL);
  }

  getMyProducts(id) {
    return this.http.get<Product[]>(this.baseURL + 'myproduct/' + id);
  }
  updateproduct(id: number, product: Product) {
    return this.http.put(this.baseURL + id, product);
  }
  deletePhoto(userId:string,productId,id:number){
    return this.http.delete(this.baseURL2+userId+'/'+productId+'/delete/'+id);
  }

}
