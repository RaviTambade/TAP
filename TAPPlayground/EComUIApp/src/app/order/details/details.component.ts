import { Component,Input,OnInit} from '@angular/core';
import { OrderhubService } from '../orderhub.service';
import { ActivatedRoute,Route,Router } from '@angular/router';
import { Order } from '../order'

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit{
  
  @Input() order:Order | undefined;
  //orders : any 
  orderId : any | undefined;

  constructor(private svc : OrderhubService,private route: ActivatedRoute,private router:Router){}
  
  
  ngOnInit(): void {
    this.route.paramMap.subscribe((params)=>{
    this.orderId = params.get('id');
    })
  }
  
   getById(id:any):void{
     this.svc.getById(id).subscribe(
       (res)=>{
        //this.orderId = res;
        console.log(res);
       }
     );
   }

   delete(id: any) {
    this.svc.delete(id).subscribe(
      (res) => {
        //this.orders=res;
        console.log(res);
    });
  }
   receiveOrder($event:any){
    this.order = $event.order

   }
  onUpdateClick(orderId:number){
    this.router.navigate(['order/updateorder',orderId])
  }
 
}

