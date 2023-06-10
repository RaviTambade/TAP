import { Injectable } from '@angular/core';


@Injectable()
export class AppService {

  getCountries() {
    //return this.countryData.getCountries();
    let countries=[
        {"name":"India","shortName": "IN"},
        {"name":"China","shortName": "Chin"},
        {"name":"America","shortName": "USA"},
    ]
    return countries;
  }


  getStatesByCountry(country: string):any {
   let  states:any;
    switch(country){
        case "India":
        states=["Maharashtra", "Gujrat","Goa"];
        return  states;
        break;
        case "China":
        states=["Zhejiang","Sichuan","Fujian"];

        break;
        case "America":
        states=["California","Texas","Florida"];
        break;
    }
    return states;
  }

  getCitiesByState(state: string) {
    let cities:any;
    switch(state){
      case "Maharashtra":
      cities=["Pune", "Ratnagiri","Mumbai"];
      return  cities;
      break;
      case "Zhejiang":
      cities=["Hangzhou","Huzhou","Jiaxing"];
      return cities;
      break;
      case "California":
      cities=["Los Angeles","San Francisco","San Diego"];
      return cities;
      break;
      case "Goa":
      cities=["Madgaon","Vasko","Kadamba"];
      return cities;
      break;
      case "Gujrat":
        cities=["Gandhi Nagar","Surat","Baroda"];
        return cities;
        break;
        

  }
    return  cities;
  }
}
