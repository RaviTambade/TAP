import { Component, Input } from '@angular/core';
import { Transaction } from '../transaction';

@Component({
  selector: 'details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
 @Input() transaction: Transaction | undefined;
}
