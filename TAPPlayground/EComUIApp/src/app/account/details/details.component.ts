import { Component, Input } from '@angular/core';
import { Account } from '../account';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {

  @Input() account: Account | undefined;
  //accounts:Account|undefined

  // onUpdate(e: any) {
  //   if (this.account != undefined)
  //     this.account.unitPrice = e.counter;
  // }

}
