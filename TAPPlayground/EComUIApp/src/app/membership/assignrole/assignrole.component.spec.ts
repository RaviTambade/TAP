import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignroleComponent } from './assignrole.component';

describe('AssignroleComponent', () => {
  let component: AssignroleComponent;
  let fixture: ComponentFixture<AssignroleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssignroleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssignroleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
