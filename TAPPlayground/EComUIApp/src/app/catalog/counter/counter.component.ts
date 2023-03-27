import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-counter',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css']
})
export class CounterComponent {
@Input() count :number |undefined;

@Output () update=new EventEmitter
onIncrement():void{
  if(this.count != undefined)
  this.count=this.count+1;
  this.update.emit({count:this.count});
}
onDecrement():void{
  if(this.count != undefined)
  this.count=this.count-1;
  this.update.emit({count:this.count});

}
}
