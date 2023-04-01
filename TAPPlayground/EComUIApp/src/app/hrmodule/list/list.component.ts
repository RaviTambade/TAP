import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from '../Employee';
import { HRHUBService } from '../hrhub.service';

@Component({
  selector: 'Emplist',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit{


  employees : Employee[] | undefined;
  
  constructor(private svc:HRHUBService,private router:Router){}
  
  ngOnInit(): void {
    this.svc.getAll().subscribe(
      (response)=>{
                    this.employees=response;
                    console.log(response);
      }
    );
  }

  onClick(empId:number) {
    
    this.router.navigate(['Employee/Emp-details',empId]);
    }

}
