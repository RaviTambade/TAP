import { Injectable } from '@angular/core';
import { Payment } from './payment';
import{HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class PaymenthubService {
  [x: string]: any;

  constructor(private http:HttpClient) { }


  public getallpayments():Observable<any>{

    let url= "http://localhost:5223/Payments/GetAll"

    return this.http.get<any>(url)


  }

  public getpaymentbyId(id:number):Observable<any>{

    let url= "http://localhost:5223/Payments/GetById/"+id;

    return this.http.get<any>(url)


  }
  public insert(payment:Payment):Observable<any>{
    let url="http://localhost:5223/payments/insert";
    return this.http.post<Payment>(url,payment);
  }

  public update(payment:Payment):Observable<any>{
    let url="http://localhost:5223/payments/update";
    return this.http.put<Payment>(url,payment);
  }
}
