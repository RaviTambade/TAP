import { Component, OnInit,
        Input, Output,EventEmitter } from '@angular/core';
 

@Component({
  selector: 'app-counter',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css']
})
export class CounterComponent implements OnInit {
  
  @Input() count:number=0;
  @Output() update=new EventEmitter();

  constructor() {
    this.count=0;
   }
  ngOnInit() {

  }
   //Event handlers
    increment(){ 
      this.count++;
      this.update.emit({count:this.count});
    }
    decrement(){this.count--;}
}