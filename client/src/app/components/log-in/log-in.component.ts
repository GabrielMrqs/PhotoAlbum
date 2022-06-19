import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss'],
})
export class LogInComponent implements OnInit {
  constructor(private service: AuthService, private router: Router) {}

  ngOnInit(): void {}

  login(value: any) {
    this.service.login(value).subscribe(() => {
      this.router.navigate([`dashboard`]);
    });
  }
}
