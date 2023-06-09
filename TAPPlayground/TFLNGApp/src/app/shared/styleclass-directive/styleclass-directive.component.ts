import { Component} from '@angular/core';

@Component({
  selector: 'branding-comp',
  templateUrl: './styleclass-directive.component.html',
  styleUrls: ['./styleclass-directive.component.css'],
})
export class BrandingComponent  {
 
  displayText:string;   
  visible:boolean;
  people: any[];

  constructor() {
    this.displayText = 'show-class'; 
    this.visible = true;    
    this.people= [
                {"name": "Michal Jackson","country": 'UK'},
                {"name": "Jerry Doyle","country": 'USA'},
                {"name": "Roger Smith","country": 'UK'},
                {"name": "Alan Border","country": 'USA'}
    ];
  }

  toggle() {
    this.visible = !this.visible;
    this.displayText = this.visible ? 'show-class' : 'hide-class';
  }

  getColor(country:string):any { 
          switch (country) {
                  case 'UK':
                    return 'green';
                  case 'USA':
                    return 'blue';
          }
  }
}