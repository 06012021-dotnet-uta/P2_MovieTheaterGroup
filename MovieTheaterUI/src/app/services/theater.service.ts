import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Theater } from '../interfaces/theater';
import { Movie } from '../interfaces/movie';
import { UrlService } from '../services/url.service';


@Injectable({
    providedIn: 'root'
})
export class TheaterService {

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };

    constructor(private http: HttpClient, private url: UrlService) { }

    // getting theaters from server
    getTheaters(): Observable<Theater[]> {
        return this.http.get<Theater[]>(`${this.url.url}Theater`);
    }

    getTheater(theaterId: number): Observable<Theater> {
        return this.http.get<Theater>(`${this.url.url}Theater/GetTheater/${theaterId}`);
    }

    //get movies at a theater
    getTheaterMovies(theaterId: number): Observable<Movie[]> {
        return this.http.get<Movie[]>(`${this.url.url}Theater/GetMovies/${theaterId}`);
    }

    //adds a theater
    addTheater(theater: Theater): Observable<Theater> {
        return this.http.post<Theater>(`${this.url.url}Theater`, theater, this.httpOptions);
    }

    //updates a theater
    updateTheater(theater: Theater): Observable<Theater> {
        return this.http.put<Theater>(`${this.url.url}Theater`, theater.theaterId, this.httpOptions);
    }

    //deletes a theater
    deleteTheater(id: number): Observable<Theater> {
        return this.http.delete<Theater>(`${this.url.url}Theater/${id}`);
    }
}
