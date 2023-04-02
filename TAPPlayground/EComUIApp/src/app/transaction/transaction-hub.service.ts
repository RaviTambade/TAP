import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Transaction } from './transaction';
@Injectable({
  providedIn: 'root'
})
export class TransactionHubService {


  constructor(private http:HttpClient) { }

  getAllTransactions():Observable<any>{
    let url= "http://localhost:5223/transaction/showalltransactions";
    return this.http.get<any>(url);
  }

  getTransactionById(transactionId:number):Observable<Transaction>{
    let url ="http://localhost:5223/transaction/gettransactionbyid/"+transactionId;
    return this.http.get<Transaction>(url);
  }

  insertTransaction(transaction:Transaction):Observable<any>{
    let url="http://localhost:5223/transaction/inserttransaction";
    console.log(transaction);
    return this.http.post<Transaction>(url,transaction);
  }

  updateTransaction(transaction:Transaction):Observable<any>{
    let url="http://localhost:5223/transaction/updatetransaction";
    return this.http.put<any>(url,transaction);
  }

  deleteTransaction(transactionId: number): Observable<any> {
    let url="http://localhost:5223/transaction/deletetransaction/"+transactionId;
    return this.http.delete<any>(url);
  }
}
