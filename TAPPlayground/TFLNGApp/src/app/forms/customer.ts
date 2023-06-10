export class Customer  {
    constructor(public  firstName:string,
                public  lastName:string,
                public  email:string,
                public  phoneNo:number,
                public  age:number,
                public  birthDate:Date,
                public location:string,
                public memberShip:string,
                public isRegistered:boolean,
                public socialStatus:string[],
               ){      
     }
    }