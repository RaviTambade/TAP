import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaggingComponent } from './pagging.component';

describe('PaggingComponent', () => {
  let component: PaggingComponent;
  let fixture: ComponentFixture<PaggingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaggingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PaggingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
