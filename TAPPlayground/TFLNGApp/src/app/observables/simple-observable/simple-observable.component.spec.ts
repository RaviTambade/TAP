import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SimpleObservableComponent } from './simple-observable.component';

describe('SimpleObservableComponent', () => {
  let component: SimpleObservableComponent;
  let fixture: ComponentFixture<SimpleObservableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SimpleObservableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SimpleObservableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
