import { Component } from '@angular/core';
import { ProducthubService } from '../producthub.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-productlist',
  templateUrl: './productlist.component.html',
  styleUrls: ['./productlist.component.css']
})
export class ProductlistComponent {
  constructor(private svc : ProducthubService, public fb : FormBuilder) {}
  isSubmitted = false;
  products= ['oats','wheat','manure','corn','barley','sorghum','karate','soloman'] ;

  ngOnInit(): void {}
  registrationForm = this.fb.group({

    selectedProduct : [ ' ', [Validators.required]],
      
    });
    changeProduct(e: any){
      this.selectedProduct?.setValue(e.target.value,{
       onlySelf : true,
      });
}

      get selectedProduct(){

       return this.registrationForm.get('selectedProduct');
        
      }

      onSubmit ():void {

        console.log(this.registrationForm);
        
        this.isSubmitted= true;
        
        if(!this.registrationForm.valid){
        
        false;
        
        }
        
        else{
        
        console.log(JSON.stringify(this.registrationForm.value));
        
        this.svc.sendProduct(this.registrationForm.value);
        
        }
        
    }

}
