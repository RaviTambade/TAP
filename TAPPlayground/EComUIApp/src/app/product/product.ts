export class Product {
    constructor(public productId:number,
        public productTitle:string,
        public description:string,
        public stockAvailable:number,
        public unitPrice:number,
        public imageUrl:string,
        public categoryId:number,
        public supplierId:number
        ){}
}
