import { Component,Input,OnInit} from '@angular/core';
import { OrderhubService } from '../orderhub.service';
import { ActivatedRoute } from '@angular/router';
import { Order } from '../order'

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit{
  
  @Input() order:Order | undefined;
  //orders : any 
  orderId : number | undefined;

  constructor(private svc : OrderhubService,private ActivatedRoute: ActivatedRoute){}
  ngOnInit(): void {
    //this.orderId = this.ActivatedRoute.snapshot.params['id'];
    //private ActivatedRoute: ActivatedRoute
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
  
  
 
}

