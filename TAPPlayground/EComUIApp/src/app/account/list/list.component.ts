import { Component, OnInit } from '@angular/core';
import { Account } from '../account';
import { AccountHubServiceService } from '../account-hub-service.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit{

  accounts: Account[] | undefined;
  constructor(private svc:AccountHubServiceService) { }
  
  ngOnInit():void {
    this.svc.getAccounts().subscribe((response) => {
      this.accounts = response;
      console.log(this.accounts);
    })
  }

  // getAll(): void {
  //   this.svc.getAccounts().subscribe((response) => {
  //     this.accounts = response;
  //     console.log(this.accounts);
  //   })

  }

