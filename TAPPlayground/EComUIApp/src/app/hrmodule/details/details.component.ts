import { Component, Input } from '@angular/core';
import { Employee } from '../Employee';
import { HRHUBService } from '../hrhub.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
   constructor(private svc:HRHUBService){}
  @Input() employee : Employee |any;
  status: boolean |undefined;

  delete(){
    console.log(this.employee.empId);
    this.svc.delete(this.employee.empId).subscribe(
      (data)=>{
        this.status=data;
        if(data){
          alert("Account Deleted Successfully");
        }
        else{
          {alert("Error")}
        }
        console.log(data);
      }
    )

  }
}
