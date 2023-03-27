import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MembershipRoutingComponent } from './membership-routing.component';

describe('MembershipRoutingComponent', () => {
  let component: MembershipRoutingComponent;
  let fixture: ComponentFixture<MembershipRoutingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MembershipRoutingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MembershipRoutingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
