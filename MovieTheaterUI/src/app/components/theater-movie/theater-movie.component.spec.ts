import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TheaterMovieComponent } from './theater-movie.component';

describe('TheaterMovieComponent', () => {
  let component: TheaterMovieComponent;
  let fixture: ComponentFixture<TheaterMovieComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TheaterMovieComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TheaterMovieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
