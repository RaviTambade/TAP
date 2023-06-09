import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sellinglist',
  templateUrl: './sellinglist.component.html',
  styleUrls: ['./sellinglist.component.css']
})
export class SellinglistComponent  implements OnInit {
flowers:any;
  constructor() { }

  ngOnInit() {

    this.flowers = [{title:'gerbera',description:"wedding Flower",unitPrice:10, quantity:2300,likes:5000,imageUrl:"./assets/images/gerbera.jpg",canSell:"true"},
    {title:'rose',description:"valentine Flower",unitPrice:6, quantity:9300,likes:4000,imageUrl:"./assets/images/gerbera.jpg",canSell:"true"},
    {title:'jasmine',description:"smelin Flower",unitPrice:12, quantity:900,likes:4560,imageUrl:"./assets/images/gerbera.jpg",canSell:"true"},
    {title:'lotus',description:"wedding Flower",unitPrice:10, quantity:2300,likes:654,imageUrl:"./assets/images/gerbera.jpg",canSell:"true"},
    {title:'marigold',description:"wedding Flower",unitPrice:10, quantity:2300,likes:45534,imageUrl:"./assets/images/gerbera.jpg",canSell:"true"},
    {title:'Lily',description:"wedding Flower",unitPrice:10, quantity:2300,likes:76,imageUrl:"./assets/images/gerbera.jpg",canSell:"true"}    ]

  }

}
