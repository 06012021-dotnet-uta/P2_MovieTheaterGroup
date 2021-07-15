import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Theater } from '../interfaces/theater';
import { Movie } from '../interfaces/movie';

@Injectable({
  providedIn: 'root'
})
export class TheaterService {

  url: string = 'https://p2movietheatergroupapi.azurewebsites.net/api/';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  // getting theaters from server
  getTheaters(): Observable<Theater[]> {
    //return this.http.get<Theater[]>('https://p2movietheatergroupapi.azurewebsites.net/api/Theater');
    return this.http.get<Theater[]>(`${this.url}Theater`);
  }

  // get movies at a theater
  getTheaterMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(`${this.url}Theater/GetMovies/{theaterId}`)
  }
}
