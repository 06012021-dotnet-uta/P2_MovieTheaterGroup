import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
// import { Theater } from '../interfaces/theater';
import { Movie } from '../interfaces/movie';
import { UrlService } from '../services/url.service';


@Injectable({
  providedIn: 'root'
})
export class MovieServiceService {

  httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

constructor(private http: HttpClient, private url: UrlService) { }
    // getting theaters from server
    getMovies(): Observable<Movie[]> {
      return this.http.get<Movie[]>(`${this.url.url}Movie/MovieList`);
  }

  getMovie(movieId: string): Observable<Movie> {
      return this.http.get<Movie>(`${this.url.url}Movie/${movieId}`);
  }

}
