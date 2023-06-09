import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'inbuilt-pipe',
  templateUrl:'./inbuilt-pipe.component.html',
  styleUrls: ['./inbuilt-pipe.component.css']
})
export class InbuiltPipeComponent {
  unitprice: number = 0.259;
  total: number = 1.3495;
  today: number = Date.now();
  flower:string="Gerbera";
  greenhouse:string="Lakshya";

  a: number = 0.678;
  b: number = 1.9852;

  constructor() { }
}