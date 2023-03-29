import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipperroutingComponent } from './shipperrouting.component';

describe('ShipperroutingComponent', () => {
  let component: ShipperroutingComponent;
  let fixture: ComponentFixture<ShipperroutingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShipperroutingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShipperroutingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
