import { Injectable } from '@angular/core';
import { tap } from 'rxjs';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private _authToken: string = 'authToken';
  constructor(private service: UserService) {}

  login(value: any) {
    return this.service.login(value).pipe(
      tap((response) => {
        localStorage.setItem(this._authToken, response);
      })
    );
  }
}
