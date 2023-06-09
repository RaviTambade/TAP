
export class Product{

    private title:string;
    private description:string;
    private quantity:number;
    private unitPrice:number;
    private imageUrl:string;
    public  likes:number;

    //No contructor overloading

    constructor(){
        this.title="Gerbera";
        this.description="Wedding Flower";
        this.quantity=5000;
        this.unitPrice=10;
        this.imageUrl="./assets/images/gerbera.jpg";
        this.likes=1200;
    }
}