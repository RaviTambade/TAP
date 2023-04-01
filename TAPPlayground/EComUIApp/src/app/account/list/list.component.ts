import { Component, OnInit, Output } from '@angular/core';
import { Account } from '../account';
import { AccountHubServiceService } from '../account-hub-service.service';
import {Router} from '@angular/router';
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit{
  @Output() accountId: number | undefined;
  accounts: Account[] | undefined;
  constructor(private svc:AccountHubServiceService,private router:Router) { }
  
  ngOnInit():void {
    this.svc.getAccounts().subscribe((response) => {
      this.accounts = response;
      console.log(this.accounts);
    })
  }

  onSelect(account:any){
    if(account!=undefined)

    this.router.navigate(['Account/account',account.accountId])
  }

  }

