import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UrlService } from '../services/url.service';
import { Schedule } from '../interfaces/schedule';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };

    constructor(private http: HttpClient, private url: UrlService) { }

    getSchedule(movieId: string, theaterId: number): Observable<Schedule[]> {
        return this.http.get<Schedule[]>(`${this.url.url}Schedule/${movieId}/${theaterId}`);
    }
}
