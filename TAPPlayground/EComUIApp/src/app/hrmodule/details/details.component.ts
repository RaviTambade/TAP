import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Employee } from '../Employee';
import { HRHUBService } from '../hrhub.service';

@Component({
  selector: 'Emp-app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {


   constructor(private svc:HRHUBService ,private route:ActivatedRoute , private router:Router ){}
   @Input() employee : Employee |any;
  status: boolean |undefined;
  empId:any|undefined;

  ngOnInit(): void {
      this.route.paramMap.subscribe((params)=>{
      this.empId=params.get('id');
    });
   
  }

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

  reciveEmployee($event: any) {
    this.employee=$event.employee;
    }

    onUpdateClick(employeeId:any) {
      this.router.navigate(['Employee/Emp-update',employeeId]);
      }
}
