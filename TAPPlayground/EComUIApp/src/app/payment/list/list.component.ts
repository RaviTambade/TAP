import { Component,OnInit } from '@angular/core';
import { Payment } from '../payment';
import { PaymenthubService } from '../paymenthub.service';

@Component({
  selector: 'ap-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit{
payments:Payment[] |undefined

constructor(private  svc:PaymenthubService){}
  ngOnInit():void{

    this.svc.getallpayments().subscribe(
      (Response)=>{
       this.payments=Response;
       console.log(Response);
      }
    )

  }

}


