import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TheaterMoviePreviewComponent } from './theater-movie-preview.component';

describe('TheaterMoviePreviewComponent', () => {
  let component: TheaterMoviePreviewComponent;
  let fixture: ComponentFixture<TheaterMoviePreviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TheaterMoviePreviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TheaterMoviePreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
