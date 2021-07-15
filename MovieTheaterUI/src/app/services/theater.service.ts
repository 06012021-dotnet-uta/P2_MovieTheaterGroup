import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Theater } from '../interfaces/theater';

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
}
