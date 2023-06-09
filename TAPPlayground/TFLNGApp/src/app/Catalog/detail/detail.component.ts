import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../product';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
  //state and behaviour
  //theProduct:Product=new  Product();
  // declare Property
  @Input() title:string|undefined;
  @Input() description:string|undefined;
  @Input() unitPrice:number=0;
  @Input() likes:number=0;
  @Input() quantity:number|undefined;
  @Input() imageUrl:string|undefined;

  constructor() { }
  ngOnInit() {
    this.likes=0;

   }
  //at parent level we have defined only event handler
  onUpdate(data:any){
    this.likes=data.count;
  }
}