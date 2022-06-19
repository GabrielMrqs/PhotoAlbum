import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseURL: string = 'https://localhost:7289';
  constructor(private http: HttpClient) {}

  public verifyUser(user: any): Observable<any> {
    return this.http.post(`${this.baseURL}/verifyUser`, user);
  }
  public addUser(user: any): Observable<any> {
    return this.http.post(`${this.baseURL}/addUser`, user);
  }
  public login(login: any): Observable<any> {
    return this.http.post(`${this.baseURL}/login`, login);
  }
}
