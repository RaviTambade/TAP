import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubjectiveComponent } from './subjective.component';

describe('SubjectiveComponent', () => {
  let component: SubjectiveComponent;
  let fixture: ComponentFixture<SubjectiveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubjectiveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubjectiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
