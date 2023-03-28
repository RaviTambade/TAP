import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetShipperComponent } from './getshipper.component';

describe('GetshipperComponent', () => {
  let component: GetShipperComponent;
  let fixture: ComponentFixture<GetShipperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetShipperComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetShipperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
