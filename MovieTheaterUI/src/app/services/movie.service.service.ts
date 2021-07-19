import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
// import { Theater } from '../interfaces/theater';
import { Movie } from '../interfaces/movie';
import { MovieComments } from '../interfaces/movieComments';
import { MovieRatings } from '../interfaces/movieRatings';
import { UrlService } from '../services/url.service';
import { MovieDescription } from '../interfaces/movieDescription';


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
    // getting movies from server
    getMovies(): Observable<Movie[]> {
        return this.http.get<Movie[]>(`${this.url.url}Movie/MovieList`);
    }
    // get a movie from API
    getMovie(movieId: string): Observable<Movie> {
        return this.http.get<Movie>(`${this.url.url}Movie/${movieId}`);
    }

    // get a movie from API
    getMovieComments(movieId: string): Observable<MovieComments[]> {
        return this.http.get<MovieComments[]>(`${this.url.url}Comment/GetAllCommentsForMovie/${movieId}`);
    }

    // get a movie from API
    getMovieRatings(movieId: string): Observable<MovieRatings[]> {
        return this.http.get<MovieRatings[]>(`${this.url.url}Rating/GetAllRaingsForMovie/${movieId}`);
    }

    getMovieDescription(movieId: string): Observable<MovieDescription> {
        return this.http.get<MovieDescription>(`${this.url.url}Movie/IMDBMovie/${movieId}`);
    }
}
