import { Product } from './../Model/Product';
import { Injectable } from '@angular/core';
import { HttpClient, HttpEventType, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ProductType } from '../Model/ProductType';

@Injectable()
export class ProductService {
  headers: Headers;

  constructor(private http: HttpClient) {
    this.headers = new Headers({ 'Content-Type': 'application/json', 'Accept': 'q=0.8;application/json;q=0.9' });
  }
  public GetAllProductsInsecure(): Observable<Product[]> {
    const Url: string = environment.baseUrl + 'products/GetProducts';

    return this.http.get<Product[]>(Url);
  }
  public uploadFile(formData: FormData) {
    const Url: string = environment.baseUrl + 'Products/UploadFile';

    this.http.post(Url, formData, {reportProgress: true, observe: 'events'})
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress){}
          //this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          // this.message = 'Upload success.';
          // this.onUploadFinished.emit(event.body);
        }
      });
  }

  public GetAllProductsSecure(): Observable<Product[]> {
    const Url: string = environment.baseUrl + 'products/getproductssecure';

    const token = localStorage.getItem('jwt');

    return this.http.get<Product[]>(Url, {
      headers: new HttpHeaders({
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'application/json'
      })
    });
  }
  public GetAllProducts(): Observable<Product[]> {
    const Url: string = environment.baseUrl + 'products/getproducts';

    return this.http.get<Product[]>(Url, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  public GetProductById(id: string): Observable<Product> {
    const Url: string = environment.baseUrl + 'products/GetProductById';
    return this.http.get<Product>(Url, { params : {id: id} });
  }

  public getProductTypes(): Observable<ProductType[]> {
    const Url: string = environment.baseUrl + 'products/getProductTypes';
    return this.http.get<ProductType[]>(Url);
  }

  public saveChanges(p: Product): Observable<boolean> {
    const Url: string = environment.baseUrl + 'products/UpdateProduct';
    const body = JSON.stringify(p);

    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.post<boolean>(Url, body, { headers });
  }

  public DeleteProduct(id: string): Observable<boolean> {
    const Url: string = environment.baseUrl + 'products/DeleteProduct';

    return this.http.delete<boolean>(Url, { params: {id: id } });
  }



}
