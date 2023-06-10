import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
@Component({
  selector: 'app-pagging',
  templateUrl: './pagging.component.html',
  styleUrls: ['./pagging.component.css']
})
export class PaggingComponent implements OnInit{
    startPosition:number=1;
    endPosition:number=1;
    selectedItems:any[] ;
    expenseEntries:any[];
    size:number=5;
  constructor(){
   
    this.expenseEntries=[
      {"item":"Pizza", "amount":1, "category":"Food", "location":"KFC", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":2, "category":"Food", "location":"Mcdonald", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":3, "category":"Food", "location":"KFC", "spenton":"12/8/2023"},
      {"item":"Pizza", "amount":4, "category":"Food", "location":"Mcdonald", "spenton":"12/1/2023"},
      {"item":"Pizza", "amount":5, "category":"Food", "location":"KFC", "spenton":"12/3/2023"},
      {"item":"Pizza", "amount":6, "category":"Food", "location":"Mcdonald", "spenton":"12/6/2023"},
      {"item":"Pizza", "amount":7, "category":"Food", "location":"v", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":8, "category":"Food", "location":"KFC", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":9, "category":"Food", "location":"Mcdonald", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":10, "category":"Food", "location":"KFC", "spenton":"12/8/2023"},
      {"item":"Pizza", "amount":11, "category":"Food", "location":"Mcdonald", "spenton":"12/1/2023"},
      {"item":"Pizza", "amount":12, "category":"Food", "location":"KFC", "spenton":"12/3/2023"},
      {"item":"Pizza", "amount":13, "category":"Food", "location":"Mcdonald", "spenton":"12/6/2023"},
      {"item":"Pizza", "amount":14, "category":"Food", "location":"v", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":15, "category":"Food", "location":"KFC", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":16, "category":"Food", "location":"Mcdonald", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":17, "category":"Food", "location":"KFC", "spenton":"12/8/2023"},
      {"item":"Pizza", "amount":18, "category":"Food", "location":"Mcdonald", "spenton":"12/1/2023"},
      {"item":"Pizza", "amount":19, "category":"Food", "location":"KFC", "spenton":"12/3/2023"},
      {"item":"Pizza", "amount":20, "category":"Food", "location":"Mcdonald", "spenton":"12/6/2023"},
      {"item":"Pizza", "amount":21, "category":"Food", "location":"v", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":22, "category":"Food", "location":"KFC", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":23, "category":"Food", "location":"Mcdonald", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":24, "category":"Food", "location":"KFC", "spenton":"12/8/2023"},
      {"item":"Pizza", "amount":25, "category":"Food", "location":"Mcdonald", "spenton":"12/1/2023"},
      {"item":"Pizza", "amount":26, "category":"Food", "location":"KFC", "spenton":"12/3/2023"},
      {"item":"Pizza", "amount":27, "category":"Food", "location":"Mcdonald", "spenton":"12/6/2023"},
      {"item":"Pizza", "amount":29, "category":"Food", "location":"v", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":30, "category":"Food", "location":"v", "spenton":"12/2/2023"}
    ];
    this.selectedItems=[];
  }

  ngOnInit(){
    this.size=5;
    this.startPosition=1;
    this.endPosition=this.startPosition+this.size;
    this.selectedItems=this.expenseEntries.slice(this.startPosition,this.endPosition);
  }

  onPrevious(){
    this.startPosition=this.startPosition-this.size;
    this.endPosition=this.startPosition+this.size;
    this.selectedItems=this.expenseEntries.slice(this.startPosition,this.endPosition);
  }
  onNext(){
    this.startPosition=this.startPosition+this.size;
    this.endPosition=this.startPosition+this.size;
    this.selectedItems=this.expenseEntries.slice(this.startPosition,this.endPosition);
  }

}
