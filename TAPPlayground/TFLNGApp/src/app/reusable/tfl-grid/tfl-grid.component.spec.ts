import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TflGridComponent } from './tfl-grid.component';

describe('TflGridComponent', () => {
  let component: TflGridComponent;
  let fixture: ComponentFixture<TflGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TflGridComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TflGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
