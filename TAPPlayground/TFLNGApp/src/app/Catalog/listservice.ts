import { Injectable } from "@angular/core";
@Injectable()  //declare as provider
export class ListService {
  list=[
        {title:'gerbera',description:"wedding Flower",unitPrice:10, quantity:2300,likes:5000,imageUrl:"./assets/images/gerbera.jpg"},
        {title:'rose',description:"valentine Flower",unitPrice:6, quantity:9300,likes:4000,imageUrl:"./assets/images/gerbera.jpg"},
        {title:'jasmine',description:"smelin Flower",unitPrice:12, quantity:900,likes:4560,imageUrl:"./assets/images/gerbera.jpg"},
        {title:'lotus',description:"wedding Flower",unitPrice:10, quantity:2300,likes:654,imageUrl:"./assets/images/gerbera.jpg"},
        {title:'marigold',description:"wedding Flower",unitPrice:10, quantity:2300,likes:45534,imageUrl:"./assets/images/gerbera.jpg"},
        {title:'Lily',description:"wedding Flower",unitPrice:10, quantity:2300,likes:76,imageUrl:"./assets/images/gerbera.jpg"}    ]

constructor(){ 
  console.log( "Service instance created !")
}

getAllProudcts():any
{   return this.list; }

getProduct(id:number):any{ return this.list[2]; }
}
