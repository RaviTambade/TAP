export class Order{
    constructor(public orderId:number,
                public orderDate:string,
                public shippedDate:string,
                public customerId:number,
                public total:number,
                public status:string)
                {}
}