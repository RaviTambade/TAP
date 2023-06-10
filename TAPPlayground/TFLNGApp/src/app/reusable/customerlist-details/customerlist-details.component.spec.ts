import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerlistDetailsComponent } from './customerlist-details.component';

describe('CustomerlistDetailsComponent', () => {
  let component: CustomerlistDetailsComponent;
  let fixture: ComponentFixture<CustomerlistDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerlistDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerlistDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
