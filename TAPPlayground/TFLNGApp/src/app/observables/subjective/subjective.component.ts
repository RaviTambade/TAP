import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, AsyncSubject, ReplaySubject } from 'rxjs';
@Component({
  selector: 'app-subjective',
  templateUrl: './subjective.component.html',
  styleUrls: ['./subjective.component.css']
})
export class SubjectiveComponent implements OnInit {

  subjectBhvr = new BehaviorSubject(13);
  subjectReply = new ReplaySubject(2, 100);
  subjectAsync = new  AsyncSubject();
  constructor() { }

  ngOnInit() { 
   //this.demoSubjectBeheaviour();
  // this.demoSubjectReplay();
   this.demoAsynSubject();
  }


  demoSubjectBeheaviour(){

    // subscriber 1
    this.subjectBhvr.subscribe((data) => {
      console.log('A Data Processed :', data);
    });

    //Math.random()

    this.subjectBhvr.next(56);
    this.subjectBhvr.next(78);

    // subscriber 2
   this.subjectBhvr.subscribe((data) => {
      console.log(' B Data Analyzed:', data);
    });

    this.subjectBhvr.next(99);
   

    console.log(this.subjectBhvr.value);

  }

  demoSubjectReplay(){
   // subscriber 1
    this.subjectReply.subscribe((data) => {console.log('A Data Processed:', data);});

    setInterval(() => this.subjectReply.next(Math.random()), 3000);

    // subscriber 2
    setTimeout(() => {
      this.subjectReply.subscribe((data) => {console.log('B Analyzed:', data);});
    },5000)

}
  
  demoAsynSubject(){

    // subscriber 1
    this.subjectAsync.subscribe((data) => {
        console.log('A Data Processed :', data);
    });

    this.subjectAsync.next(Math.random())
    this.subjectAsync.next(Math.random())
    this.subjectAsync.next(Math.random())

    // subscriber 2
    this.subjectAsync.subscribe((data) => {
        console.log('B Data Analyzed:', data);
    });

    this.subjectAsync.next(Math.random());
    this.subjectAsync.complete();
  }
}
