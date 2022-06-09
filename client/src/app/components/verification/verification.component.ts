import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import jwtDecode from 'jwt-decode';
import { Client } from 'src/app/models/client';
import { ClientService } from 'src/app/services/client.service';

@Component({
  selector: 'app-verification',
  templateUrl: './verification.component.html',
  styleUrls: ['./verification.component.scss'],
})
export class VerificationComponent implements OnInit {
  token: string;
  client: Client;
  success: boolean = true;
  constructor(private route: ActivatedRoute, private service: ClientService) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.token = params['token'];
      this.addClient();
    });
  }

  private addClient() {
    let data: any = jwtDecode(this.token);
    this.client = new Client(data.username, data.password, data.email);
    this.service
      .addClient(this.client)
      .subscribe({ error: () => (this.success = false) });
  }
}
