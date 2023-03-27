import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InserttransactionComponent } from './inserttransaction.component';

describe('InserttransactionComponent', () => {
  let component: InserttransactionComponent;
  let fixture: ComponentFixture<InserttransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InserttransactionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InserttransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
