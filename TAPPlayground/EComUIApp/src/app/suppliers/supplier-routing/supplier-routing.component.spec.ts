import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupplierRoutingComponent } from './supplier-routing.component';

describe('SupplierRoutingComponent', () => {
  let component: SupplierRoutingComponent;
  let fixture: ComponentFixture<SupplierRoutingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SupplierRoutingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SupplierRoutingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
