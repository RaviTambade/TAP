import { Component, OnInit } from '@angular/core';
import { Subscription, Observable } from 'rxjs';
import { MessageService } from '../../messageservice';

@Component({
  selector: 'app-consumer2',
  templateUrl: './consumer2.component.html',
  styleUrls: ['./consumer2.component.css']
})
export class Consumer2Component implements OnInit {

  message: string;
  subscription: Subscription;

  constructor(private messageService: MessageService) {  }

  ngOnInit() {
  let theObservable:Observable<any> = this.messageService.getMessage();
  this.subscription =theObservable .subscribe(msg => { this.message = msg; });
   }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
