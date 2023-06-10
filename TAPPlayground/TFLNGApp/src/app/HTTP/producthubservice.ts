
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { MessageAPIService } from './messageapiservice';
import { Product } from './product';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class ProductService {

  private webapiUrl = 'http://localhost:7000/api/products'; 

  constructor(
    private http: HttpClient,
    private messageService: MessageAPIService) { }

  getProducts (): Observable<Product[]> {
    return this.http.get<Product[]>(this.webapiUrl)
      .pipe(
        tap(products => this.log(`fetched products`)),
        catchError(this.handleError('getProducts', []))
      );
  }


  getProductNo404<Data>(id: number): Observable<Product> {
    const url = `${this.webapiUrl}/?id=${id}`;
    return this.http.get<Product[]>(url)
      .pipe(
        map(products => products[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} product id=${id}`);
        }),
        catchError(this.handleError<Product>(`getProduct id=${id}`))
      );
  }

 
  getProduct(id: number): Observable<Product> {
    const url = `${this.webapiUrl}/${id}`;
    return this.http.get<Product>(url).pipe(
      tap(_ => this.log(`fetched product id=${id}`)),
      catchError(this.handleError<Product>(`getProduct id=${id}`))
    );
  }


  searchProducts(term: string): Observable<Product[]> {
    if (!term.trim()) {
      // if not search term, return empty product array.
      return of([]);
    }
    return this.http.get<Product[]>(`${this.webapiUrl}/?title=${term}`).pipe(
      tap(_ => this.log(`found matching products "${term}"`)),
      catchError(this.handleError<Product[]>('searchProducts', []))
    );
  }

 
 addProduct (product: Product): Observable<Product> {
    return this.http.post<Product>(this.webapiUrl, product, httpOptions).pipe(
      tap((product: Product) => this.log(`added Product w/ id=${product.productID}`)),
      catchError(this.handleError<Product>('addProduct'))
    );
  }

 
  deleteProduct (product: Product | number): Observable<Product> {
    const id = typeof product === 'number' ? product : product.productID;
    const url = `${this.webapiUrl}/${id}`;

    return this.http.delete<Product>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted hero id=${id}`)),
      catchError(this.handleError<Product>('deleteProduct'))
    );
  }


  updateProduct (product: Product): Observable<any> {
    return this.http.put(this.webapiUrl, product, httpOptions).pipe(
      tap(_ => this.log(`updated product id=${product.productID}`)),
      catchError(this.handleError<any>('updateProduct'))
    );
  }


  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error); // log to console instead
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

  private log(message: string) {
    this.messageService.add('ProductService: ' + message);
  }
}