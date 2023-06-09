import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GDIComponent } from './gdi.component';

describe('GDIComponent', () => {
  let component: GDIComponent;
  let fixture: ComponentFixture<GDIComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GDIComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GDIComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
