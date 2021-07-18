import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieCommentsComponentComponent } from './movie-comments-component.component';

describe('MovieCommentsComponentComponent', () => {
  let component: MovieCommentsComponentComponent;
  let fixture: ComponentFixture<MovieCommentsComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieCommentsComponentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieCommentsComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
