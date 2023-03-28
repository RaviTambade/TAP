import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductRoutingComponent } from './product-routing.component';

describe('ProductRoutingComponent', () => {
  let component: ProductRoutingComponent;
  let fixture: ComponentFixture<ProductRoutingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductRoutingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductRoutingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
