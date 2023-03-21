import { Component, OnInit } from '@angular/core';
//logic and behaviour of component
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  //data members
  amount:number=678;
  title:string = 'EStore';
  company:string='Transflower';
  status:boolean=true;
  person:any;
  product:any;
  email="ravi.tambade@transflower.in";
  password="123";


  //constructor is always used for dependency injection
  constructor(){
  }

  ngOnInit(): void {
    //access data from external rest api
    this.person={
      "firstname":"Akshay",
      "lastname":"Tanpure",
      "location":"Rajguru Nagar",
      "email":"akshay.tanpure@gmail.com"
    };
  
    this.product= {
      "id":45,
      "title":"Ferrari",
      "description":"Smart Car",
      "imageurl":"./assets/images/ferrari.jpeg",
      "quantity":50,
      "unitprice":800000
    }
  }

  //member functions Event Handlers
  
  onButtonClick(){
    console.log("button is clicked....")
  }

  onLoginClick(){
    //let keyword is used to define scope variable
    let txtEmail=this.email;
    let txtPassword=this.password;
    console.log("Login is clicked...." + txtEmail + " "+ txtPassword);
  }

  onRegisterClick(){
    console.log("Register is clicked....")
  }


  //separation of conern
  //loosely coupled architecture
}
