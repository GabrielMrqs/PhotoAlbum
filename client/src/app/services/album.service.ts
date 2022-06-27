import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Photo } from '../models/photo';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {
  baseURL: string = 'https://localhost:7050';
  constructor(private http: HttpClient) {}

  public getAlbum(id: any): Observable<any> {
    return this.http.get(`${this.baseURL}/getAlbum/${id}`,);
  }
  public addPhoto(photo: Photo): Observable<any> {
    return this.http.put(`${this.baseURL}/addPhoto`, photo);
  }
}
