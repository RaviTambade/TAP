import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AccountService } from '../accountservice';

@Component({
  selector: 'sbi-bank',
  templateUrl: './bank.component.html',
  styleUrls: ['./bank.component.css']
})
export class BankComponent implements OnInit {

  package: any;
  subscriptionTDS: Subscription|undefined;
  subscriptionGST: Subscription|undefined;
  subscriptionGiftTax: Subscription|undefined;
 
  constructor(private svc: AccountService) {  }

  ngOnInit() {
    //Observers
    this.subscriptionGiftTax = this.svc.getAccount()
    .subscribe(amt => { this.package = amt;
                        if(this.package.amount >200000){ 
                            this.package.amount=this.package.amount * 0.7;
                            console.log("Gift Tax Deducted !");
                          }
                      });

    this.subscriptionTDS = this.svc.getAccount()
    .subscribe(amt => { this.package = amt;
                        if(this.package.amount >50000){ 
                            this.package.amount=this.package.amount * 0.9;
                            console.log("TDS Deducted !");
                          }
                      });

    this.subscriptionGST = this.svc.getAccount()
    .subscribe(amt => { this.package = amt;
                        if(this.package.amount > 500){
                        this.package.amount=this.package.amount * 0.9;
                        console.log("GST Deducted !");
                      } 
               });

   }

  ngOnDestroy() {
    if (this.subscriptionTDS !== undefined) {
      this.subscriptionTDS.unsubscribe();
    }

    if (this.subscriptionGST !== undefined) {
      this.subscriptionGST.unsubscribe();
    }

    if (this.subscriptionGiftTax !== undefined) { 
      this.subscriptionGiftTax.unsubscribe();
    }
  }
}