export class Product{
    constructor(public id:number,
                public title:string,
                public unitPrice:number,
                public stockAvailable:number,
                public image:string,
                public categoryId:number,
                public categoryTitle:string)
                {}
}