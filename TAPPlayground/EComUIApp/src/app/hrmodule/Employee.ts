export class Employee{
    constructor(
        public empId:number,
        public empFirstName:string,
        public empLastName:String,
        public birthDate:string,
        public hireDate:string,
        public contactNumber:string,
        public email:string,
        public password:string,
        public photo:string,
        public reportsTo:number,
        public accountNumber:string
    ){}
}