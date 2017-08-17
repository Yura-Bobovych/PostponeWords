import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {
	constructor(private router: Router) { }

	canActivate() {

		if (!localStorage['auth_token']) {
			this.router.navigate(['/account/login']);
			return false;
		}

		return true;
	}
}