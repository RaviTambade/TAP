import { Pipe, PipeTransform } from "@angular/core";
 
export interface Seller{
  canSell:boolean;
}


@Pipe({ name: 'sellingflowers' })
export class SellingflowersPipe implements PipeTransform {

transform(allfloweres: any[]) {
  return allfloweres.filter(flower => (flower.price <30));
}

}