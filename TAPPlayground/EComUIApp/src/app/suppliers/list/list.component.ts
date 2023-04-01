import { Component } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Supplier } from '../supplier';
import { SupplierhubService } from '../supplierhub.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent {
  suppliers: Supplier[] | undefined;
  
  constructor(private svc: SupplierhubService,private router:Router) { }
  
  ngOnInit(): void {
    this.svc.getAll().subscribe((response) => {
      this.suppliers = response;
      console.log(this.suppliers);
    })
  }
  onSelect(supplier:any){
    if(supplier!=undefined)
    this.router.navigate(['supplier/suppliers',supplier.supplierId]); 
   }
  }

