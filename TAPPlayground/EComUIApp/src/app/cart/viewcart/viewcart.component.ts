import { Component, OnInit } from '@angular/core';
import { Cart } from '../cart';
import { CartService } from '../cartservice.service';

@Component({
  selector: 'app-viewcart',
  templateUrl: './viewcart.component.html',
  styleUrls: ['./viewcart.component.css']
})
export class ViewcartComponent implements OnInit {

 cart :Cart |undefined;

 path = "assets/";
 constructor(private svc:CartService){}
 ngOnInit(): void {
  this.svc.getCart(2).subscribe((response)=>{
    this.cart=response;
    console.log(response);
  });
}
}
