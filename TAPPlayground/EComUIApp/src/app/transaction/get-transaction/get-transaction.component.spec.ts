import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetTransactionComponent } from './get-transaction.component';

describe('GetTransactionComponent', () => {
  let component: GetTransactionComponent;
  let fixture: ComponentFixture<GetTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetTransactionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
