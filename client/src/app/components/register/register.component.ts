import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  constructor(private service: UserService) {}
  ngOnInit() {}

  register(value: any) {
    this.service.verifyUser(value)
    .subscribe();
  }
}
