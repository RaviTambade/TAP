import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
               
@Injectable()
export class MessageService {
    private subject = new Subject<any>();
   
    sendMessage(message: string) {
    this.subject.next({ text: message });
         //it is publishing this value to all the subscribers 
         //that have already subscribed to this message
    }

    clearMessage() {
        this.subject.next();
    }

    getMessage(): Observable<any> {
        return this.subject.asObservable();
    }
}