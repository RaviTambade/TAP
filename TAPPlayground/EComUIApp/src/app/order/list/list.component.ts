import { Component,OnInit } from '@angular/core';
import { Order } from '../order';
import { OrderhubService } from '../orderhub.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit{

  orders : Order[] | undefined
  constructor(private svc :OrderhubService){

  }
  ngOnInit(): void {
    this.svc.getAllOrders().subscribe(
      (response)=>{
        this.orders = response;
        console.log(response);
      }
   );
  }
  // getAllOrders():void{
  // this.svc.getAllOrders().subscribe(
  //   (response)=>{
  //     this.orders =response;
  //     console.log(response);
  //   }
  // );

  // }

}
