import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router } from '@angular/router';
import { Supplier } from '../supplier';
import { SupplierhubService } from '../supplierhub.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  supplier: Supplier | any;
  status: boolean | undefined;
  sub: any;
  supplierId: any;
  
  constructor(private svc: SupplierhubService,private router:ActivatedRoute,private route:Router) { }

 
  ngOnInit(): void {
   
    this.sub=this.router.paramMap.subscribe((params)=>{
      console.log(params)
      this.supplierId=params.get('id');
  })
  }

  updateSupplier() {
    this.svc.update(this.supplier).subscribe((response) => {
      this.status = response;
      if(response){
        alert("Supplier updated Successfully")
        this.route.navigate(['supplier/suppliers']);
       }
       else{
        alert("Error while updating suppliers")
       }
      })
    }
  
  receiveSupplier($event: any) {
    this.supplier = $event.supplier
  }

}
