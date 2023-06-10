import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class MessageAPIService {
  messages: string[] = [];

  add(message: string) {
    this.messages.push(message);
  }

  clear() {
    this.messages = [];
  }
}
