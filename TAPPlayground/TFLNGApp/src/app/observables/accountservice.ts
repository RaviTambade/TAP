import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable()
export class AccountService {
    private subject = new Subject<any>();

    transfer(amount: number) {
        this.subject.next({ amount: amount });
    }

    clear() {
        this.subject.next({ amount: 0 });
    }

    getAccount(): Observable<any> {
        return this.subject.asObservable();
    }
}