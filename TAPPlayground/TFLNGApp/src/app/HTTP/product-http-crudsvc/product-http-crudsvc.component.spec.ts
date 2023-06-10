import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductHttpCRUDSVCComponent } from './product-http-crudsvc.component';

describe('ProductHttpCRUDSVCComponent', () => {
  let component: ProductHttpCRUDSVCComponent;
  let fixture: ComponentFixture<ProductHttpCRUDSVCComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductHttpCRUDSVCComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductHttpCRUDSVCComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
