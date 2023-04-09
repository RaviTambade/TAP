import { Component } from '@angular/core';
import { Cart } from '../cart';

@Component({
  selector: 'app-viewcart',
  templateUrl: './viewcart.component.html',
  styleUrls: ['./viewcart.component.css']
})
export class ViewcartComponent {
 cart :Cart |undefined;
 
}
