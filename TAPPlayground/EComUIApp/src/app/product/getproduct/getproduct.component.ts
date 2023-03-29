import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Product } from '../product';
import { ProductHubService } from '../producthub.service';

@Component({
  selector: 'getproduct',
  templateUrl: './getproduct.component.html',
  styleUrls: ['./getproduct.component.css']
})
export class GetproductComponent implements OnInit {

 @Input() productId: number | undefined;
  product: Product | undefined;

  @Output() sendProduct =new EventEmitter();
  constructor(private svc: ProductHubService) { }

  ngOnInit(): void {
      if(this.productId!=undefined){
      this.svc.getProductById(this.productId).subscribe((response) => {
      this.product = response;
      this.sendProduct.emit({product:this.product});
      console.log(this.product);
  })
}
}

  getProductById(id: any) {
    this.svc.getProductById(id).subscribe((response) => {
      this.product = response;
      this.sendProduct.emit({product:this.product});
      console.log(this.product);
    })

}
}
