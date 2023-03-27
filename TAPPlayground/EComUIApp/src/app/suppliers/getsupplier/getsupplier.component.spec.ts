import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetsupplierComponent } from './getsupplier.component';

describe('GetsupplierComponent', () => {
  let component: GetsupplierComponent;
  let fixture: ComponentFixture<GetsupplierComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetsupplierComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetsupplierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
