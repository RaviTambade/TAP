import { Component, OnInit } from '@angular/core';
import { Product } from '../product';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

 products:Product[]=[
    {ID:12,title:"Gerbera",description:"Wedding flower",unitPrice:6, balance:5000},
    {ID:13,title:"Carnation",description:"Funtime flower",unitPrice:6, balance:14000},
    {ID:14,title:"Lilly",description:"Joy flower",unitPrice:4, balance:23000},
    {ID:15,title:"Louts",description:"worship flower",unitPrice:26, balance:4000},
    {ID:16,title:"Rose",description:"Valentine flower",unitPrice:6, balance:12000},
  ]

  constructor(private router: Router, private route: ActivatedRoute) {  }
  
  ngOnInit() { }

  goToProduct(id:number): void {

    this.router.navigate(['./', id], {relativeTo: this.route});
  }
}

