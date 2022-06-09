import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ClientService {
  baseURL: string = 'https://localhost:7289';
  constructor(private http: HttpClient) {}

  public verifyClient(client: any): Observable<any> {
    return this.http.post(`${this.baseURL}/verifyClient`, client);
  }
  public addClient(client: any): Observable<any> {
    return this.http.post(`${this.baseURL}/addClient`, client);
  }
  public login(login: any): Observable<any> {
    return this.http.post(`${this.baseURL}/login`, login);
  }
}
