import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClientService } from 'src/app/services/client.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss'],
})
export class LogInComponent implements OnInit {
  constructor(private service: ClientService, private router: Router) {}

  ngOnInit(): void {}

  login(value: any) {
    console.log(value)
    this.service.login(value).subscribe((res: any) => {
      this.router.navigate([`dashboard/${res}`])
    });
  }
}
