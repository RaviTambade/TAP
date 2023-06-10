import { Component, OnInit } from '@angular/core';
import { AccountService } from '../accountservice';

@Component({
  selector: 'salary-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  ngOnInit() {  }
  amount:number;

  constructor(private svc: AccountService) {}
  
  transfer() { this.svc.transfer(this.amount); }
  clear() { this.svc.clear(); }
}
