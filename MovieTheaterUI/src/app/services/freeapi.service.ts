
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient, HttpParams } from "@angular/common/http";

import { Posts } from "../classes/posts";
import { Params } from "@angular/router";
import { MovieComments } from "../classes/moviecomments";


@Injectable()
export class freeApiService{

    constructor(private httpclient: HttpClient){}

    getcomments(): Observable<any>{
        return this.httpclient.get("https://jsonplaceholder.typicode.com/posts/1/comments")
    }

    getcommentsbyparameter(): Observable<any>{
        let params1 = new HttpParams().set('userId', "1");

        return this.httpclient.get("https://jsonplaceholder.typicode.com/posts", {params:params1});
    }

    post(opost:MovieComments): Observable<any>{
        return this.httpclient.post("https://localhost:44367/api/Comment", opost);
    }

    getmoviecomments(): Observable<any>{
        return this.httpclient.get("https://localhost:44367/api/Comment/GetAllCommentsForMovie/666");

    }


}
