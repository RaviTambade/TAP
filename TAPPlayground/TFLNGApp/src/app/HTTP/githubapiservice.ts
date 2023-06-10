import {Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from './git-http/user';
import { Observable} from 'rxjs';
import {tap } from 'rxjs/operators';

@Injectable()
export class GithubAPIService {

  userUrl:string="https://api.github.com/users/";

  constructor(private http: HttpClient) {  }

  getUser (name:string): Observable<User> {
    return this.http.get<User>(this.userUrl+name).pipe(
        tap(users => console.log(`fetched users*********` +users))
      );
  }
}