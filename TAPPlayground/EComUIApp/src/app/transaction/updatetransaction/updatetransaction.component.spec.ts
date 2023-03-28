import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatetransactionComponent } from './updatetransaction.component';

describe('UpdatetransactionComponent', () => {
  let component: UpdatetransactionComponent;
  let fixture: ComponentFixture<UpdatetransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdatetransactionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdatetransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
