import { Component,Input,OnInit } from '@angular/core';
import { ShipperhubService } from '../shipperhub.service';
import { Shipper } from '../shipper';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'detailsshipper',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  @Input () shipper: Shipper| any ;
  shipperId: any | undefined ;
  //shippId:any|undefined;
  status: boolean |undefined;

  constructor(private svc:ShipperhubService,private route:ActivatedRoute , private router:Router){

  }
  ngOnInit(): void {

    this.route.paramMap.subscribe((params)=>{
      this.shipperId=params.get('id')
    })
  }
  getById(Shipperid:any):void{
  this.svc.getById(Shipperid).subscribe(
    (res)=>{
      this.shipper = res;
      console.log(res);
    }
  )

  }
  reciveShipper($event :any){
  this.shipper=$event.shipper;
  }
  

  delete(){
    console.log(this.shipper.shipperId);
    this.svc.delete(this.shipper.shipperId).subscribe(
      (data)=>{
        this.status=data;
        if(data){
          alert("Shipper Deleted Successfully");
        }
        else{
          {alert("Error")}
        }
        console.log(data);
      }
    )


  }

    onUpdateClick(shipperId:any) {
      this.router.navigate(['Shipper/updateshipper',shipperId]);
      }
}
  
