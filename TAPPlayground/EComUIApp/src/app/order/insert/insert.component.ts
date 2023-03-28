import { Component,OnInit } from '@angular/core';
import { Order } from '../order';
import { OrderhubService } from '../orderhub.service';


@Component({
  selector: 'app-insert',
  templateUrl: './insert.component.html',
  styleUrls: ['./insert.component.css']
})
export class InsertComponent implements OnInit {

  order : Order ={orderId:0,
                  orderDate:'',
                  shippedDate:'',
                  customerId:0,
                  total:0,
                  status:''
           }
  status:boolean   | undefined

  model= {"orderId":0,
          "orderDate": "yy-mm-dd hh-mm-ss",
          "shippedDate":"yy-mm-dd hh-mm-ss",
          "customerId":0 ,
          "total": 0 ,
          "status":''
  };

  

  constructor(private svc:OrderhubService){
  
  }
  ngOnInit(): void {

  }
    insertOrder(form:any){
      this.svc.insertOrder(form).subscribe(
        (res)=>{
          this.status = res;
          console.log(res);
        }
      );
    }
}



