import { Component, OnInit, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit ,OnDestroy{

  constructor() { 
    console.log("Contact construct");
  }

  ngOnInit() {
    console.log("Contact init");
  }

  ngOnDestroy(){
    console.log("Contact onDestroy");
  }
}
