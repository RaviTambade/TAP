import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartroutingComponent } from './cartrouting.component';

describe('CartroutingComponent', () => {
  let component: CartroutingComponent;
  let fixture: ComponentFixture<CartroutingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CartroutingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CartroutingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
