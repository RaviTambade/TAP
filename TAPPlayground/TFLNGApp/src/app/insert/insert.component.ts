import { Component } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Product } from '../product';
@Component({
  selector: 'app-insert',
  templateUrl: './insert.component.html',
  styleUrls: ['./insert.component.css']
})
export class InsertComponent {

  constructor(private http : HttpClient) { }

   product:Product={
     id: 0,
     title: ' ',
     unitPrice: 0,
     stockAvailable: 0,
     image: ' ',
     categoryId: 0,
     categoryTitle: ''
   }

  status:boolean |undefined;

  insertProduct(form:any){

    console.log("data received on submit form");

    console.log(form);
    let url ="http://localhost:5214/api/catalogs/";
    

    let theProduct=new Product(34, form.title, form.unitPrice, form.stockAvailable,form.image,form.categoryId,form.categoryTitle);
    

   
    /*this.http.get(url).subscribe(
      (res)=>{
        console.log(res);
      }
    )
  */

    console.log("Produt object data");
    console.log(theProduct);

     this.http.post<Product>(url,form).subscribe(
      (res)=>{
        console.log(res);
      }
    ); 
  

    


  }

}
