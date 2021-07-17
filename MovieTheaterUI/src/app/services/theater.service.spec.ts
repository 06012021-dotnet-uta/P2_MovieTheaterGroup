import { TestBed } from '@angular/core/testing';
import { HttpClientModule} from '@angular/common/http';
import { TheaterService } from './theater.service';

describe('TheaterService', () => {
  let service: TheaterService;

  beforeEach(() => {
    TestBed.configureTestingModule({
        imports: [HttpClientModule],
    });
    service = TestBed.inject(TheaterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
