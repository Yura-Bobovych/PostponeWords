import { Injectable } from '@angular/core';

import { Http } from '@angular/http'
import { User } from './models'

@Injectable()
export class AccountService {

	constructor(private httpService: Http) { }

	Register(user: User) {
		this.httpService.post('api/account/register', user).subscribe(Response => { console.log(Response) })
	}
	Login(user: User) {
		this.httpService.post('api/account/login', user).subscribe(Response => { console.log(Response) })
	}
}
