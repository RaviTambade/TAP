import { Component, OnInit } from '@angular/core';
import { Payment } from '../payment';
import { PaymenthubService } from '../paymenthub.service';

@Component({
  selector: 'ap-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit{

  payment: Payment | any;
  status: boolean | undefined;
   

  constructor(private svc: PaymenthubService) { }

 ngOnInit(): void {
     
 }
 
 
  update() {
    
    this.svc.update(this.payment).subscribe((response) => {
      this.status = response;
      console.log(response);
    })
  }


  recivePayment($event:any){
    
    this.payment=$event.payment
    
  }

}
