import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {
  baseURL: string = 'https://localhost:7050';
  constructor(private http: HttpClient) {}

  public getAlbum(id: any): Observable<any> {
    return this.http.get(`${this.baseURL}/getAlbum/${id}`,);
  }
  public addPhoto(client: any): Observable<any> {
    return this.http.post(`${this.baseURL}/addPhoto`, client);
  }
}
