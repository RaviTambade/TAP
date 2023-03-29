import { Component ,OnInit} from '@angular/core';
import { Shipper } from '../shipper';
import { ShipperhubService } from '../shipperhub.service';

@Component({
  selector: 'ListShipper',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  
  shippers:Shipper[] | undefined

  constructor(private svc:ShipperhubService){ 
  }
  ngOnInit(): void {
   
      this.svc.getAllShippers().subscribe (
       (response)=>{
        this.shippers = response;
        console.log(response);
      }
   );

  }
    
    

}
