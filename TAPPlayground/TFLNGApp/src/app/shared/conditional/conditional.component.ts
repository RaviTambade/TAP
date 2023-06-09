import { Component, 
          OnInit,
          OnDestroy } from '@angular/core';

@Component({
  selector: 'app-conditional',
  templateUrl: './conditional.component.html',
  styleUrls: ['./conditional.component.css']
})
export class ConditionalComponent implements OnInit,OnDestroy {
 //public :number;
 public billingPrice:number=0;
 public productionCost:number=0;
 public flower:string|undefined;
 public bestflower:string|undefined;

 constructor() {
  
 }

 isFlowerAvailable():boolean{  return true; }


 //overridable method given by inteface onInit
 //Initialization at Angular Engine
 ngOnInit() { 

    //localstroage
    //sessionstorage
    //indexdb
    // tocken
    this.productionCost=65;
    this.billingPrice=123;
    this.flower='gerbera';
    this.bestflower='rose';
  }


  //cleanup at Angular rendering Engine
  ngOnDestroy(){
    // release resource  before your component get destroyed

  }
}