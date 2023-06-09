import { Injectable } from '@angular/core';

import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class LoginserviceService {

  status:boolean=false;

  constructor() { }

  validate(userName:string, password:string):boolean{
   
    if(userName==="ravi" && password==="tfl")
    {
      this.status=true;
    }

    return this.status;
  }

  getUser(userName:string):User
  {

    //will have logic to call REST API , 
    //get data asynchronously from server 
    //create instance of user and pass to components who are depedennt
    /*..............*/
    
    return new User("ravi","tambade","ravi.tambade@transflower.in");

    
  }
}
