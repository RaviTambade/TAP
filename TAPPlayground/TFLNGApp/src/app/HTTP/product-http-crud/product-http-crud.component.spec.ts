import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductHttpCRUDComponent } from './product-http-crud.component';

describe('ProductHttpCRUDComponent', () => {
  let component: ProductHttpCRUDComponent;
  let fixture: ComponentFixture<ProductHttpCRUDComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductHttpCRUDComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductHttpCRUDComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
