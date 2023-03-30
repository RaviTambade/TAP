import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import{Shipper} from './shipper';


@Injectable({
  providedIn: 'root'
})
export class ShipperhubService {

  constructor(private http:HttpClient) { }

public getAllShippers():Observable<any>{

let url ="http://localhost:5223/shipper/getallShippers";
return this.http.get<any>(url)

}
public getById(ShipperId:number):Observable<any>{

  let url ="http://localhost:5223/shipper/getShipperById/"+ShipperId;
  return this.http.get<any>(url)

}


insertShipper(shipper:Shipper):Observable<any>{
  let url="http://localhost:5223/shipper/Insertshipper";
  console.log(shipper);
  return this.http.post<Shipper>(url,shipper);
}

updateShipper(shipper:Shipper):Observable<any>{
  let url="http://localhost:5223/shipper/Updateshipper";
  console.log(shipper);
  return this.http.put<Shipper>(url,shipper);
}

delete(shipperId:number):Observable<any>{

  let url ="http://localhost:5223/shipper/DeleteShipper/"+shipperId;
  return this.http.delete<Shipper>(url);
}
}


