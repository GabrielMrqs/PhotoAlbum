import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AlbumService } from 'src/app/services/album.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  authToken: string = 'authToken';
  token: any;
  id: string | null;
  photos: any[];
  constructor(
    private service: AlbumService,
    private jwtHelper: JwtHelperService
  ) {}

  ngOnInit(): void {
    this.token = this.getToken();
    this.id = this.getUserId(this.token);
    this.service.getAlbum(this.id).subscribe((res) => {
      this.photos = res;
    });
  }

  private getUserId(token: any) {
    return token.userId;
  }

  private getToken(): any {
    let encodedToken = localStorage.getItem(this.authToken);
    return this.jwtHelper.decodeToken(encodedToken!);
  }
}
