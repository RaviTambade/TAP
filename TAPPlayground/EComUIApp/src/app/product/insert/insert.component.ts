import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../product';
import { ProductHubService } from '../producthub.service';

@Component({
  selector: 'insert',
  templateUrl: './insert.component.html',
  styleUrls: ['./insert.component.css']
})
export class InsertComponent implements OnInit {
  product: Product = {
    productId: 0,
    productTitle: '',
    description: '',
    stockAvailable: 0,
    unitPrice: 0,
    imageUrl: '',
    categoryId: 0,
    supplierId: 0
  };
  status: boolean | undefined;
  categories:[] |any;
  suppliers:[]|any;

  constructor(private svc: ProductHubService, private router: Router) { }
  ngOnInit(): void {
    //categories
    this.svc.getCategories().subscribe((response) => {
      this.categories = response;
      console.log(response);
    });
    // suppliers
    this.svc.getSuppliers().subscribe((response) => {
      this.suppliers = response;
      console.log(response);
    });
  }


  insertProduct() {
    console.log(this.product)
    this.svc.insertProduct(this.product).subscribe((response) => {
      this.status = response;
      console.log(response);
      if (response) {
        window.location.reload();
        alert("record Inserted successfully")
      }
      else {
        alert("Error while Inserting record")
      }
    })
  }


}
