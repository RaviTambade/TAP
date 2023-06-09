import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SellinglistComponent } from './sellinglist.component';

describe('SellinglistComponent', () => {
  let component: SellinglistComponent;
  let fixture: ComponentFixture<SellinglistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SellinglistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SellinglistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
