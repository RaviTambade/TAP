export class Payment{
    constructor(
        public paymentId:number,
        public paymentDate:string,
        public paymentMode: string,
        public transactionId:number,
        public orderId:number

        ){}
}