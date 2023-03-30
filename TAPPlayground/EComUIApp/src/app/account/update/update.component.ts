import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route } from '@angular/router';
import { Account } from '../account';
import { AccountHubServiceService } from '../account-hub-service.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {


  account: Account | any;
  status: boolean | undefined;
  accountId:any
  sub:any

  constructor(private svc: AccountHubServiceService,private route:ActivatedRoute) { }
  ngOnInit(): void {
    this.sub=this.route.paramMap.subscribe((params)=>{
      console.log(params)
      this.accountId=params.get('id');
    })
  }

  update() {
    
    this.svc.update(this.account).subscribe((response) => {
      this.status = response;
      console.log(response);
    })
  }
  receiveAccount($event: any) {
    this.account = $event.account
  }
}
