import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule} from '@angular/common/http';
import { TheaterMoviePreviewComponent } from './theater-movie-preview.component';

describe('TheaterMoviePreviewComponent', () => {
  let component: TheaterMoviePreviewComponent;
  let fixture: ComponentFixture<TheaterMoviePreviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
        imports: [HttpClientModule],
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
