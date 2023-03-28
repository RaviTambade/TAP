import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../product';
import { ProductHubService } from '../producthub.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  product: Product|any;
  status: boolean | undefined;
  sub: any;
  productId: any;

 
  constructor(private svc: ProductHubService,private route:ActivatedRoute) { }
  ngOnInit(): void {
   
    this.sub=this.route.paramMap.subscribe((params)=>{
      console.log(params)
      this.productId=params.get('id');
  })
  }

  updateProduct() {
    this.svc.updateProduct(this.product).subscribe((response)=>{
      this.status = response;
      console.log(response);
    })

  }

  // from getbyid
  reciveProduct($event: any) {
    this.product = $event.product
  }

}
