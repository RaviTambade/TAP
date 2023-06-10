import { Component, OnInit } from '@angular/core';
import { Subscription, Observable } from 'rxjs';
import { MessageService } from '../../messageservice';

@Component({
  selector: 'app-consumer1',
  templateUrl: './consumer1.component.html',
  styleUrls: ['./consumer1.component.css']
})
export class Consumer1Component implements OnInit {

  message: string|undefined;
  subscription: Subscription|undefined;

  constructor(private messageService: MessageService) {  }

  ngOnInit() {
  let theObservable:Observable<any> = this.messageService.getMessage();
  this.subscription =theObservable .subscribe(msg => { this.message = msg.text; });
   }

  ngOnDestroy() {
    if(this.subscription!=undefined){
      this.subscription.unsubscribe();
    }
  }
}
