import { Component,OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AppService } from '../aap.service';


interface Country {
  shortName: string;
  name: string;
}
@Component({
  selector: 'nested-dropdown',
  templateUrl: './nested-dropdown.component.html',
  styleUrls: ['./nested-dropdown.component.css']
})
export class NestedDropdownComponent implements OnInit {
  form: FormGroup;
  //matcher = new MyErrorStateMatcher();

  countries: any;
  states: string[] | undefined;
  cities: string[] | undefined;

  country = new FormControl(null, [Validators.required]);

  state = new FormControl({ value: null, disabled: true }, [Validators.required,]);
  city = new FormControl({ value: null, disabled: true }, [Validators.required,]);
  
  constructor(private service: AppService) {
    //fetch all available countries from service
    this.countries = this.service.getCountries();

    this.form = new FormGroup({
      country: this.country,
      state: this.state,
      city: this.city,
    });
  }
  ngOnInit(): void {
     this.country.valueChanges.subscribe((country) => {
      this.state.reset();
      this.state.disable();
      if (country) {
        this.states = this.service.getStatesByCountry(country);
        this.state.enable();
     }
    });

    this.state.valueChanges.subscribe((state) => {
      this.city.reset();
      this.city.disable();
      if (state) {
        this.cities = this.service.getCitiesByState(state);
        this.city.enable();
      }
    });
  }
}
