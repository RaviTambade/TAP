import { Component,OnInit} from '@angular/core';
import { OrderhubService } from '../orderhub.service';
import { Order } from '../order'
import { ActivatedRoute } from '@angular/router';

 @Component({
   selector: 'app-update',
    templateUrl: './update.component.html',
    styleUrls: ['./update.component.css']
  })
  export class UpdateComponent implements OnInit{

    order: Order | any;
    status:boolean | undefined;
    orderId:any;
    constructor(private svc:OrderhubService,private route:ActivatedRoute){}
    
    update() {
      console.log("updated");
      this.svc.update(this.order).subscribe(
        (res)=>{
          this.status = res;
          console.log(res);
        }
      )
    }
    
  ngOnInit(): void {
      this.route.paramMap.subscribe((param)=>{
        this.orderId = param.get('id');
      })
  }
    //from getbyid
    receiveOrder($event:any){
    this.order = $event.order
    }
  };

