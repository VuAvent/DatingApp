import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { __values } from 'tslib';
import { UserLogin } from '../_models/userLogin';
import { UserRegister, UserToken } from '../_models/users';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AccountsService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      // Authorization: 'my-auth-token'
    })
  };
  baseUrl = "https://localhost:5001/api/accounts";
  private currentUser = new BehaviorSubject<UserToken>(null as unknown as UserToken);
  currentUser$ = this.currentUser.asObservable();

  constructor(private httpClient: HttpClient) { }

  login(user: UserLogin): Observable<any> {
    return this.httpClient.post<any>(`${this.baseUrl}/login`, user, this.httpOptions)
      .pipe(map((response: UserToken) => {
        const user = response;
        if (user) {
          localStorage.setItem('userToken', JSON.stringify(user));
          this.currentUser.next(user);
        }
      }))
  }

  logout(){
    localStorage.removeItem("userToken");
    this.currentUser.next(null as unknown as UserToken);
  }

  register(user: UserRegister) {
    return this.httpClient
      .post<any>(`${this.baseUrl}/register`, user, this.httpOptions)
      .pipe(map((response: UserToken) => {
        const user = response;
        if (user) {
          localStorage.setItem('userToken', JSON.stringify(user));
          this.currentUser.next(user);
        }
      }))

  }

}
