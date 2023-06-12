import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  list:any=[
    {id:1,title:'gerbera',description:"wedding Flower",unitPrice:10, quantity:2300,likes:5000,imageUrl:"./assets/images/gerbera.jpg"},
    {id:2,title:'rose',description:"valentine Flower",unitPrice:6, quantity:9300,likes:4000,imageUrl:"./assets/images/gerbera.jpg"},
    {id:3,title:'jasmine',description:"smelin Flower",unitPrice:12, quantity:900,likes:4560,imageUrl:"./assets/images/gerbera.jpg"},
    {id:4,title:'lotus',description:"wedding Flower",unitPrice:10, quantity:2300,likes:654,imageUrl:"./assets/images/gerbera.jpg"},
    {id:5,title:'marigold',description:"wedding Flower",unitPrice:10, quantity:2300,likes:45534,imageUrl:"./assets/images/gerbera.jpg"},
    {id:6,title:'Lily',description:"wedding Flower",unitPrice:10, quantity:2300,likes:76,imageUrl:"./assets/images/gerbera.jpg"}];

  constructor() { }

  getAllProudcts():any
  { return this.list; }
  
  getProduct(id:number):any
  { 
    console.log("selected product id="+ id);
    //return {id:6,title:'Lily',description:"wedding Flower",unitPrice:10, quantity:2300,likes:76,imageUrl:"./assets/images/gerbera.jpg"};
   return this.list.find((p:any)=>{ return p.id ==id});
  }
}
