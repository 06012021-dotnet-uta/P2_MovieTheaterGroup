import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { MessageService } from '../message.service';
import { User } from '../interfaces/user';
import { USERS } from '../mock-data/mock-data';

@Injectable({
  providedIn: 'root'
})
export class UserService {
   // url: string = 'https://localhost:5001/api/RpsGame/';
    // url : string = 'https://localhost:5001/api/User/';
    httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    // constructor(private http: HttpClient) { }
    constructor(private messageService: MessageService,
      private http: HttpClient) { }
      // https://localhost:5001/api/User

      // https://localhost:5001/api/User/UserList

  // befor getting role from server
  // getRoles() : Observable<Role[]> {
  //   const roles = of(ROLES)
  //   this.messageService.add('RoleService: fetched roles');
  //   return roles;
  // }

  // getting roles from server
  getUsers() : Observable<User[]> {
    //return this.http.get<Role[]>('https://localhost:5001/api/User/UserList');
    return this.http.get<User[]>('https://localhost:5000/api/User');

  }

  getUser(id : number) : Observable<User>{
    const user = USERS.find(r => r.userId == id)! ;
    this.messageService.add(` UserService : fetched user id=${id}`);
    return of(user)
  }

  /** PUT: update the role on the server */
  // updateUser(user: User): Observable<any> {
  //   return this.http.put(this.usersUrl, user, this.httpOptions).pipe(
  //     tap(_ => this.log(`updated user userId=${user.UserId}`)),
  //     catchError(this.handleError<any>('updateUser'))
  //   );
  // }


}
