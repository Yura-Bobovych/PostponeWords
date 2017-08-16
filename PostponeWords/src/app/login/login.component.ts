import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { User } from "../models";
import { AccountService } from "../account.service"

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

	login = 'login';
	constructor(private accService: AccountService) { }
	onSubmit(form: NgForm) {
		var user = new User(form.value.email, form.value.password);
		if (form.value.account == "login") {			
			this.accService.Login(user)
		}
		if (form.value.account == "register") {
			this.accService.Register(user)
		}
  }
  

}
