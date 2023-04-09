import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HikepriceComponent } from './hikeprice.component';

describe('HikepriceComponent', () => {
  let component: HikepriceComponent;
  let fixture: ComponentFixture<HikepriceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HikepriceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HikepriceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
