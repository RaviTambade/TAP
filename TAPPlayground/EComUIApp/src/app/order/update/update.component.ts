import { Component} from '@angular/core';
import { OrderhubService } from '../orderhub.service';
import { Order } from '../order'

 @Component({
   selector: 'app-update',
    templateUrl: './update.component.html',
    styleUrls: ['./update.component.css']
  })
  export class UpdateComponent{

    order: Order | any;
    status:boolean | undefined;

    constructor(private svc:OrderhubService){}
    
    update() {
      console.log("updated");
      this.svc.update(this.order).subscribe(
        (res)=>{
          this.status = res;
          console.log(res);
        }
      )
    }
    

    //from getbyid
    receiveOrder($event:any){
    this.order = $event.order
    }
  };

