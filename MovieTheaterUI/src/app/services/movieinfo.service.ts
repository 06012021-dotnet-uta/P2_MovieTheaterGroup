import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Movie } from '../interfaces/movie';
import { UrlService } from '../services/url.service';

export class MovieInfoService {

    constructor(private http: HttpClient, private url: UrlService) { }

    //get movies at a theater
    getTheaterMovies(theaterId: number): Observable < Movie[] > {
        return this.http.get<Movie[]>(`${this.url.url}Theater/GetMovies/${theaterId}`);
    }
}
