import { Injectable } from '@angular/core';
import { Customer } from './customer';

@Injectable()
export class CustomerService {

  constructor() { }

  getAll() : Customer[] {
    return [
        {"name": "Sajan", "email":"sajan.pande@gmail.com", "contactnumber":"9881735801", "account":"7858756"},
        {"name": "Meera", "email":"meera.mohan@gmail.com", "contactnumber":"9881735678", "account":"7898456"},
        {"name": "Shaila", "email":"shaila.kumari@gmail.com", "contactnumber":"9888745801", "account":"7859856"},
        {"name": "Shiv", "email":"shiv.khera@gmail.com", "contactnumber":"9881987801", "account":"7856756"},
        {"name": "Charan", "email":"charan.s@gmail.com", "contactnumber":"9881872301", "account":"7856756"},
        {"name": "Mangesh", "email":"mangesh.patil@gmail.com", "contactnumber":"9881735801", "account":"7096756"},
        {"name": "Sarika", "email":"sarika.jadhav@gmail.com", "contactnumber":"9881735801", "account":"7856986"},
        {"name": "Chandra", "email":"sajan.pande@gmail.com", "contactnumber":"9881787941", "account":"7349834"}
  
    ];
  }

}