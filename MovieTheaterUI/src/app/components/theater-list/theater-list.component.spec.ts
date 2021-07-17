import { TheaterListComponent } from './theater-list.component';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule} from '@angular/common/http';

describe('TheaterListComponent', () => {
  let component: TheaterListComponent;
  let fixture: ComponentFixture<TheaterListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
        imports: [HttpClientModule],
      declarations: [ TheaterListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TheaterListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
