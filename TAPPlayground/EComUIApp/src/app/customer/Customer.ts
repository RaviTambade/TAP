export class Customer{
    constructor(
        public customerId:number,
        public firstName:string,
        public lastName:string,
        public email:string,
        public password:string,
        public contactNumber:number,
        public accountNumber:number
    ){}
}