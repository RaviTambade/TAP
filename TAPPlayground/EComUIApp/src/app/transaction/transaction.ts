export class Transaction {
    constructor( public transactionId:number,
                 public fromAccountNumber:number,
                 public toAccountNumber:number,
                 public transactionDate:string,
                 public amount:number
    ){}
}