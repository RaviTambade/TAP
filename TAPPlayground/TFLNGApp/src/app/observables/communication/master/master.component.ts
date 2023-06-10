import { Component, OnInit } from '@angular/core';
import { MessageService } from '../../messageservice';

@Component({
  selector: 'app-master',
  templateUrl: './master.component.html',
  styleUrls: ['./master.component.css']
})
export class MasterComponent implements OnInit {

  ngOnInit() {  }
  message:string="";

  constructor(private messageService: MessageService) {}
    
  sendMessage() {
        // send message to subscribers via observable subject
        this.messageService.sendMessage(this.message);
    }

  clearMessage() {
        this.messageService.clearMessage();
    }

}
