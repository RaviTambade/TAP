import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription, Observable } from 'rxjs';
import { MessageService } from '../../messageservice';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit,OnDestroy {
  subscription: Subscription;
  message: string;

  constructor(private messageService: MessageService) {  }
  
  ngOnInit() {
  let theObservable:Observable<any> = this.messageService.getMessage();
  this.subscription =theObservable .subscribe(
    msg => { 
      this.message = msg;
      console.log(" Detail Component :event handler is called")
   });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
