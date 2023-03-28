import { Component, OnInit } from '@angular/core';
import { Employee } from '../Employee';
import { HRHUBService } from '../hrhub.service';

@Component({
  selector: 'list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit{

  employees : Employee[] | undefined;
  
  constructor(private svc:HRHUBService){}
  
  ngOnInit(): void {
    this.svc.getAll().subscribe(
      (response)=>{
                    this.employees=response;
                    console.log(response);
      }
    );
  }

}
