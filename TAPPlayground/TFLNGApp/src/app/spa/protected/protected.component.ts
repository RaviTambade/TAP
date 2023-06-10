import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'protected-comp',
  templateUrl: './protected.component.html',
  styleUrls: ['./protected.component.css']
})
export class ProtectedComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
