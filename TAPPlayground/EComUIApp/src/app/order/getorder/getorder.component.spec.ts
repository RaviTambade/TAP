import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetorderComponent } from './getorder.component';

describe('GetorderComponent', () => {
  let component: GetorderComponent;
  let fixture: ComponentFixture<GetorderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetorderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetorderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
