import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule} from '@angular/common/http';
import { TheaterMovieComponent } from './theater-movie.component';

describe('TheaterMovieComponent', () => {
  let component: TheaterMovieComponent;
  let fixture: ComponentFixture<TheaterMovieComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
        imports: [HttpClientModule],
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
