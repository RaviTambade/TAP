import { Component } from '@angular/core';
import { Employee } from '../Employee';
import { HRHUBService } from '../hrhub.service';

@Component({
  selector: 'update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent {
  
    employee : Employee | any;
    status:boolean |undefined;

    constructor(private svc:HRHUBService){}

    update(){
      this.svc.update(this.employee).subscribe(
        (response)=>{
          this.status=response;
          console.log(response);
        }
      )
    };

    receiveEmployee($event: any ){
      this.employee=$event.employee;
    }
}
