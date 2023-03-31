import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeRoutingComponent } from './employee-routing.component';

describe('EmployeeRoutingComponent', () => {
  let component: EmployeeRoutingComponent;
  let fixture: ComponentFixture<EmployeeRoutingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeRoutingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeRoutingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
