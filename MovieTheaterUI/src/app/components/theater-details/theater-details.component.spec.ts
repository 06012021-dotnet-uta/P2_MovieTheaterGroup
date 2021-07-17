import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule} from '@angular/common/http';
import { TheaterDetailsComponent } from './theater-details.component';

describe('TheaterDetailsComponent', () => {
  let component: TheaterDetailsComponent;
  let fixture: ComponentFixture<TheaterDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
        imports: [ HttpClientModule],
      declarations: [ TheaterDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TheaterDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
