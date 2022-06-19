import { Component, OnInit } from '@angular/core';
import { AlbumService } from 'src/app/services/album.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  userId: string = 'userId';
  id: string | null;
  photos: any[];
  constructor(private service: AlbumService) {}

  ngOnInit(): void {
    this.id = localStorage.getItem(this.userId);
    this.service.getAlbum(this.id).subscribe((res) => {
      this.photos = res;
    });
  }


}
