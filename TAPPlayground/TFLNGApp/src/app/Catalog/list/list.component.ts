import { Component, OnInit } from '@angular/core';
import {ListService} from '../listservice';

@Component({
  selector: 'selling-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
  //providers:[ListService]  
})
export class ListComponent implements OnInit {
 
   products:any;

   //Perform dependency injection
  constructor(private svc:ListService) { }

  ngOnInit() {

    this.products=this.svc.getAllProudcts();
  }

}
