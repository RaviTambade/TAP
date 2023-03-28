import { Component, Input } from '@angular/core';
import { Supplier } from '../supplier';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
  @Input() supplier:Supplier | undefined;

}
