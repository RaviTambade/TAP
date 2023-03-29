import { ComponentFixture, TestBed } from '@angular/core/testing';

import {InsertShipperComponent} from './insert.component';

describe('InsertComponent', () => {
  let component: InsertShipperComponent;
  let fixture: ComponentFixture<InsertShipperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InsertShipperComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsertShipperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
