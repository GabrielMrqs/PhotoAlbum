import { Component, OnInit } from '@angular/core';
import { ClientService } from 'src/app/services/client.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  constructor(private service: ClientService) {}
  ngOnInit() {}

  register(value: any) {
    this.service.verifyClient(value)
    .subscribe();
  }
}
