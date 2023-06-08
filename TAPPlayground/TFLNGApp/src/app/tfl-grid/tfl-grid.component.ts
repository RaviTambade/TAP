import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'tfl-grid',
  templateUrl: './tfl-grid.component.html',
  styleUrls: ['./tfl-grid.component.css']
})
export class TflGridComponent implements OnInit {

  expenseEntries:any[];
  constructor(){
    this.expenseEntries=[];

  }
  ngOnInit(): void {

    this.expenseEntries=[
      {"item":"Pizza", "amount":10, "category":"Food", "location":"KFC", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":15, "category":"Food", "location":"Mcdonald", "spenton":"12/2/2023"},
      {"item":"Pizza", "amount":23, "category":"Food", "location":"KFC", "spenton":"12/8/2023"},
      {"item":"Pizza", "amount":27, "category":"Food", "location":"Mcdonald", "spenton":"12/1/2023"},
      {"item":"Pizza", "amount":12, "category":"Food", "location":"KFC", "spenton":"12/3/2023"},
      {"item":"Pizza", "amount":11, "category":"Food", "location":"Mcdonald", "spenton":"12/6/2023"},
      {"item":"Pizza", "amount":18, "category":"Food", "location":"v", "spenton":"12/2/2023"}
    ];
  }
}