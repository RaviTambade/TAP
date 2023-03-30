import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from '../Employee';
import { HRHUBService } from '../hrhub.service';

@Component({
  selector: 'Empupdate',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  
    employee : Employee | any;
    status:boolean |undefined;
    employeeId:any;

    constructor(private svc:HRHUBService , private  route :ActivatedRoute){}
  ngOnInit(): void {
    
      this.route.paramMap.subscribe((params)=>{
      this.employeeId=params.get('id');
    })
  }


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
