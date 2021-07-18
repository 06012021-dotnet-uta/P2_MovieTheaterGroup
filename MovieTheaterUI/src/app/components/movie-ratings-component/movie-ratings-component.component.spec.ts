import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieRatingsComponentComponent } from './movie-ratings-component.component';

describe('MovieRatingsComponentComponent', () => {
  let component: MovieRatingsComponentComponent;
  let fixture: ComponentFixture<MovieRatingsComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieRatingsComponentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieRatingsComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
