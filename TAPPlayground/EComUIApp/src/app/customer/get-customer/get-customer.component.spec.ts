import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetCustomerComponent } from './get-customer.component';

describe('GetCustomerComponent', () => {
  let component: GetCustomerComponent;
  let fixture: ComponentFixture<GetCustomerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetCustomerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
