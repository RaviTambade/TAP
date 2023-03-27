import { Component, OnInit } from '@angular/core';
import { identity } from 'rxjs';
import { Product } from 'src/app/product';
import { ProducthubService } from 'src/app/producthub.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  constructor(private svc:ProducthubService){

  }
ngOnInit(): void {
 
}
productId :any |undefined;
product:Product |undefined;


getById(id:number){
   this.svc.getById(id).subscribe((response)=>{
    this.product=response;
   })
}
}


