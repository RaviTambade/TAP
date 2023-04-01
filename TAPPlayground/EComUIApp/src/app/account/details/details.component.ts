import { Component, Input,OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Account } from '../account';
import { AccountHubServiceService } from '../account-hub-service.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  constructor(private svc: AccountHubServiceService,private route:ActivatedRoute,private router:Router) { }
  ngOnInit(): void {
    console.log("hii")
    this.route.paramMap.subscribe((params)=>{
      console.log(params)
      this. accountId=params.get('id');
    })
  }
  @Input() account: Account | any;
  status: boolean | undefined

  accountId:any


reciveAccount($event:any){
  console.log("event")
  this.account=$event.account;
  console.log(this. accountId);
}


  deleteAccount() {
    console.log(this.account.accountId);
    this.svc.delete(this.account.accountId).subscribe((data) => {
      this.status = data;
      if (data) { alert("Account Deleted Successfully") 
    }else{
{alert("Error")}
    }
      console.log(data);
    })
  }
  onSelectUpdate(accountId:any){
    this.router.navigate(['Account/updateAccount',accountId]);
  }
}
