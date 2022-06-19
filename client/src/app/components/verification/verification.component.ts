import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import jwtDecode from 'jwt-decode';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-verification',
  templateUrl: './verification.component.html',
  styleUrls: ['./verification.component.scss'],
})
export class VerificationComponent implements OnInit {
  token: string;
  user: User;
  success: boolean = true;
  constructor(private route: ActivatedRoute, private service: UserService) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.token = params['token'];
      this.addUser();
    });
  }

  private addUser() {
    let data: any = jwtDecode(this.token);
    this.user = new User(data.username, data.password, data.email);
    this.service
      .addUser(this.user)
      .subscribe({ error: () => (this.success = false) });
  }
}
