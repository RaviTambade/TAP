import { Component, OnInit } from '@angular/core';
import { GithubAPIService } from '../githubapiservice';

export class User  {  
  constructor(public name:string,
              public location:string,
              public company:string,
              public blog:string)  { }
  } 

@Component({
  selector: 'git-http',
  templateUrl: './git-http.component.html',
  styleUrls: ['./git-http.component.css']
})
export class GitHTTPComponent implements OnInit {
  userName:string="ravitambade"
  data: Object;
  loading : boolean=false;
  user:User; 
  
  constructor(private svc: GithubAPIService) {
  this.user=new   User("","","","");
  }

  ngOnInit() {}
  makeRequest(): void {
    this.loading = true;
   
    this.svc.getUser(this.userName).subscribe(usr => { this.user = usr;
                                                      this.data=usr;
                                                      console.log(usr);
                                                      this.loading = true;
                                                      },
                                              err=>{console.log(err)});
  }
}