import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { map, filter } from 'rxjs/operators';
// to work with streamming data
//we need special kind of library fore reative javascript collection

@Component({
  selector: 'simple-observable',
  templateUrl: './simple-observable.component.html',
  styleUrls: ['./simple-observable.component.css']
})
export class SimpleObservableComponent implements OnInit {

  names = ['mastercard', 'infosys', 'transflower','capgemini','persistent','indus', 'vodafone'];  
  data="seed";

  source = from(this.names);
  //source=this.names;
  
  constructor() { }
  ngOnInit() { }

  show() {
      this.names.push(this.data);

      

      //register function callback function
      this.source.subscribe(
          value => console.log("On First Observer : "+ value),//onSuccess
          error => console.log(error), //onError
          () => console.log(" First complete")  // finally default execution
      );
 
      this.source.pipe(map(name => name.toUpperCase()))
          .subscribe(
                    value => console.log("On Second Observer : "+value),
                    error => console.log(error),
                    () => console.log(" Second complete")
      );
    
     
 
      this.source.pipe(filter(name => name.startsWith('i')))
          .subscribe(name => {console.log("On Third Observer : "+ name)});    
      }   

     
}