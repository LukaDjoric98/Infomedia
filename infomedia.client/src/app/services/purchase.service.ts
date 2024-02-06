import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Purchase } from '../models/purchase';

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {
  
  private apiUrl = `http://localhost:5283/api/purchase`;

  constructor(private http: HttpClient) { }

  purchaseUsingPhoneAndPin(purchase: Purchase): Observable<any>{
    return this.http.post<any>(this.apiUrl, purchase).pipe(
      catchError(this.handleError<any>('purchaseUsingPhoneAndPin'))
    );
  }

  protected handleError<T>(operation = 'operation', result?: T){
    return (error: any): Observable<T> => {
      console.error(error);
      return throwError(new Error());
    }
  }
}
