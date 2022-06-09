import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AlbumService } from 'src/app/services/album.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  id: string;
  photos: any[];
  constructor(private route: ActivatedRoute, private service: AlbumService) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.id = params['id'];
      this.service.getAlbum(this.id).subscribe((res) => {
        this.photos = res;
      });
    });
  }

  toBase64(photo:string){
    return `data:image/png;base64,${photo}`;
  }
}
