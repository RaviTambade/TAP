import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductssupplierComponent } from './productssupplier.component';

describe('ProductssupplierComponent', () => {
  let component: ProductssupplierComponent;
  let fixture: ComponentFixture<ProductssupplierComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductssupplierComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductssupplierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
