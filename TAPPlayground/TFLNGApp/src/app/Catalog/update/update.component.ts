import { Component, OnInit } from '@angular/core';
import { ListService } from '../listservice';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css'],
  //providers:[ListService]  
})
export class UpdateComponent implements OnInit {

  constructor(svc:ListService) {

   }

  ngOnInit() {
  }

}
