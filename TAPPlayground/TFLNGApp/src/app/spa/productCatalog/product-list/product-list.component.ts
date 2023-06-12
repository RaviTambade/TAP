import { Component, OnInit } from '@angular/core';
import { Product } from '../product';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductService } from '../../product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

 products:any[]=[]

  constructor(private svc:ProductService,private router: Router, private route: ActivatedRoute) {  }
  
  ngOnInit() { 
    this.products=this.svc.getAllProudcts();
  }

  goToProduct(id:number): void {
    console.log(id);
    this.router.navigate(['./details',id]);
  }
}

