import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MutipleSelectListBoxComponent } from './mutiple-select-list-box.component';

describe('MutipleSelectListBoxComponent', () => {
  let component: MutipleSelectListBoxComponent;
  let fixture: ComponentFixture<MutipleSelectListBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MutipleSelectListBoxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MutipleSelectListBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
