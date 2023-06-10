import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GitHTTPComponent } from './git-http.component';

describe('GitHTTPComponent', () => {
  let component: GitHTTPComponent;
  let fixture: ComponentFixture<GitHTTPComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GitHTTPComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GitHTTPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
