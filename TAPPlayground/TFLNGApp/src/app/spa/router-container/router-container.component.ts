import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'spa-container',
  templateUrl: './router-container.component.html',
  styleUrls: ['./router-container.component.css']
})
export class RouterContainerComponent implements OnInit {

  loggedInStatus:boolean|undefined;
 
  links:any=[];

  constructor(){
    this.links=["home","about","services", "protected"];
  }
  convertToBoolean(result:string):boolean{
    let status=false;
    if(result=="true"){
      status=true;
    }
    return status;
  }

  ngOnInit() {
    console.log("Router container component ngOnint is getting invoked");
      let strStatus:string|null=localStorage.getItem("loggedInStatus");
      console.log( " in routerocntainer strStatus ="+strStatus);
      if(strStatus!=null){
        this.loggedInStatus=true;
        //this.convertToBoolean(strStatus);
        console.log(this.loggedInStatus);
      }

  }
}
