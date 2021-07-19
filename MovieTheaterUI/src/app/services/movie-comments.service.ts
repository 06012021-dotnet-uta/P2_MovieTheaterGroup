import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MovieCommentsMap } from '../interfaces/movieComments';
import { UrlService } from './url.service';

@Injectable({
  providedIn: 'root'
})
export class MovieCommentsService {

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };

    constructor(private http: HttpClient, private url: UrlService) {}

    addComment(movieComment: MovieCommentsMap): Observable<MovieCommentsMap> {
        console.log(movieComment);
        return this.http.post<MovieCommentsMap>(`${this.url.url}Comment`, movieComment);
    }
}
