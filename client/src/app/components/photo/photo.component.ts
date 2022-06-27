import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-photo',
  templateUrl: './photo.component.html',
  styleUrls: ['./photo.component.scss'],
})
export class PhotoComponent implements OnInit {
  @Input() photo: string;
  @Input() description: string;
  @Input() title: string;
  constructor() {}

  ngOnInit(): void {}

  toBase64(photo: string) {
    // return `data:image/png;base64,${photo}`;
    return photo;
  }
}
