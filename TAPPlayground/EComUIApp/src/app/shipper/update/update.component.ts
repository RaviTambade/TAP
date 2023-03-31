import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Shipper } from '../shipper';
import { ShipperhubService } from '../shipperhub.service';

@Component({
  selector: 'updateshipper',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit{
    shipper: Shipper | any;
    status: boolean | undefined;
    shipperId:any;
  
    constructor(private svc: ShipperhubService,private route:ActivatedRoute,private router:Router) { }
  ngOnInit(): void {
    this.route.paramMap.subscribe((params)=> {
     this.shipperId=params.get('id');
    })
   console.log(this.shipper) ;
  }
  
    updateShipper() {
      this.svc.updateShipper(this.shipper).subscribe((response) => {
        this.status = response;
        console.log(response);
        if (response){
          alert("shipper Updated Successfully")
          this.router.navigate( ['/shipperlist'])
           }
          else{
           alert("error");
           
          }
        
      })
    }
    receiveShipper($event: any) {
      this.shipper = $event.shipper

    }
  
  }

