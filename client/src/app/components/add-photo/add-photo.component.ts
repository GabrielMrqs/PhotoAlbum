import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ImagePickerConf } from 'ngp-image-picker';
import { Photo } from 'src/app/models/photo';
import { AlbumService } from 'src/app/services/album.service';

@Component({
  selector: 'app-add-photo',
  templateUrl: './add-photo.component.html',
  styleUrls: ['./add-photo.component.scss']
})
export class AddPhotoComponent implements OnInit {
  constructor(private modalService: NgbModal, private albumService: AlbumService,
    private jwtHelper: JwtHelperService, private router: Router) { }
  @ViewChild('photoModal') modal: ElementRef;
  imagePickerConf: ImagePickerConf = {
    borderRadius: '4px',
    language: 'en',
    width: '100%',
    height: '300px',
    hideDeleteBtn: true,
    hideDownloadBtn: true,
    hideEditBtn: true,
    hideAddBtn: true,
  };
  token: any;
  id: string;
  photo: string;
  authToken: string = 'authToken';
  ngOnInit(): void {
    this.token = this.getToken();
    this.id = this.getUserId(this.token);
  }

  public openModal() {
    this.modalService.open(this.modal);
  }

  public onImageChange(photo: string) {
    this.photo = photo;
  }

  public uploadPicture(modal: any) {
    let photo = new Photo(
      modal.title,
      modal.description,
      this.photo,
      this.id);
    this.albumService.addPhoto(photo).subscribe(() => {
      window.location.reload();
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
