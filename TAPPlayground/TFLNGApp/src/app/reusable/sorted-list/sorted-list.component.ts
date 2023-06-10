import { Component } from '@angular/core';

@Component({
  selector: 'sorted-list',
  templateUrl: './sorted-list.component.html',
  styleUrls: ['./sorted-list.component.css']
})
export class SortedListComponent {
  // numbers:any[];
  expenseEntries:any[];

  constructor(){
    // this.numbers=[1,4,3,8,2,5,10,8,11,20,13,22,13,44,15,56,17,28,39,20];
    this.expenseEntries=[
      {"item":"Pizza", "amount":1600, "category":"Food", "location":"Pune", "spenton":"1/2/2023"},
      {"item":"Pizza", "amount":1250, "category":"Food", "location":"Ratnagiri", "spenton":"12/2/2021"},
      {"item":"Pizza", "amount":3150, "category":"Food", "location":"Mumbai", "spenton":"12/8/2019"},
      {"item":"Pizza", "amount":2150, "category":"Food", "location":"Solapur", "spenton":"12/2/2022"},
      {"item":"Pizza", "amount":1950, "category":"Food", "location":"Kolhapur", "spenton":"19/2/2024"}
    ];
  };


onClickLocaiton(){
  this.expenseEntries.sort((expense1,expense2)=>{
    let fa = expense1.location.toLowerCase(),
        fb = expense2.location.toLowerCase();
    if (fa < fb) {
        return -1;
    }
    if (fa > fb) {
        return 1;
    }
    return 0;
});

}
onClickDate(){
  this.expenseEntries.sort((expense1,expense2)=> Date.parse(expense1.spenton) - Date.parse(expense2.spenton));
}
onClickAmount(){
  this.expenseEntries.sort((expense1,expense2)=> expense1.amount-expense2.amount);
}
}
