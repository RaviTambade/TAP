import { Component, OnInit } from '@angular/core';
import { ProducthubService } from 'src/app/producthub.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  products:any =[];

constructor(private svc:ProducthubService){

}
  ngOnInit(): void {
   this.products=this.svc.getAllProducts().subscribe((response)=>{
      this.products=response;
      console.log(this.products);
   });
  }
  onUpdate(o:any){
    this.products.unitPrice=o.count;
  }


}
