import { Component, Input, OnInit } from '@angular/core';
import { Supplier } from '../supplier';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  supplierId:any;
  supplier:Supplier |undefined;

  ngOnInit(): void {}
  
  receiveSupplier($event:any){
    this.supplier=$event.supplier;
  }
}