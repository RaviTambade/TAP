import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountRoutingComponent } from './account-routing.component';

describe('AccountRoutingComponent', () => {
  let component: AccountRoutingComponent;
  let fixture: ComponentFixture<AccountRoutingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccountRoutingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccountRoutingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
