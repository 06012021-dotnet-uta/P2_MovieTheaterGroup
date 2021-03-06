import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of , BehaviorSubject} from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { MessageService } from '../message.service';
import { User } from '../interfaces/user';
import { USERS } from '../mock-data/mock-data';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private authorizedUser: User = {
        userId: 0,
        //username: 'bricor',
        username: '',
        passwd: '',
        firstName: '',
        lastName: '',
        //roleId: 2
        roleId: 0
    };
    private usersUrl = 'https://localhost:5001/api/User';  // URL to web api
    private url: string = 'https://p2movietheatergroupapi.azurewebsites.net/api/'
    // url : string = 'https://localhost:5001/api/User/';
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };
    // constructor(private http: HttpClient) { }
    constructor(private messageService: MessageService,
        private http: HttpClient) { }
    // https://localhost:5001/api/User/UserList

    // getting roles from server
    getUsers(): Observable<User[]> {
        // return this.http.get<User[]>('https://localhost:5001/api/User');
        return this.http.get<User[]>(`${this.url}User`);
    }


    getUser(id: number): Observable<User> {
        return this.http.get<User>(`${this.url}User/${id}`);
        // return this.http.get<User>(`${'https://localhost:5001/api/User'}/${id}`);
    }

    AddUser(user: User): Observable<User> {
        return this.http.post<User>(`${this.url}User/CreateNewUser/`, user, this.httpOptions)
    }

    // delete
    DeleteUser(id: number): Observable<User> {
        return this.http.delete<User>(`${this.url}User/${id}`, this.httpOptions);
        // return this.http.delete<User>(`${'https://localhost:5001/api/User'}/${id}`, this.httpOptions);
    }

    AuthorizedUser(user: User) {
        this.authorizedUser = user;
    }

    // get current user
    GetCurrentUser(): User {
        return this.authorizedUser;
    }

}
  // update


