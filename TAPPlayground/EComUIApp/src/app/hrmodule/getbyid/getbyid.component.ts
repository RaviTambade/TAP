import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { Employee } from '../Employee';
import { HRHUBService } from '../hrhub.service';

@Component({
  selector: 'Empgetbyid',
  templateUrl: './getbyid.component.html',
  styleUrls: ['./getbyid.component.css']
})
export class GetbyidComponent {

  empId : number | undefined;
  employee:Employee| any;
  status:boolean|undefined;

  @Output() sendEmployee=new EventEmitter;
  constructor(private svc:HRHUBService,private datepipe:DatePipe){}

  getById(id:any){
    this.svc.getById(id).subscribe(
      (response)=>{
        this.employee=response;
        this.employee.birthDate=this.datepipe.transform(this.employee.birthDate,'yyyy-MM-dd hh.mm.ss');
        this.employee.hireDate=this.datepipe.transform(this.employee.hireDate,'yyyy-MM-dd hh.mm.ss');
        console.log(this.employee.birthDate);
        console.log(this.employee.hireDate);
        console.log(response);
        this.sendEmployee.emit({employee:this.employee});
      }
    )
  }


}
