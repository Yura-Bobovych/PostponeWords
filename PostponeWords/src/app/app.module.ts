import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';


import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { MainComponent } from './main/main.component';
import { AccountService } from "./account.service"

const appRoutes: Routes = [
	{ path: '', component: MainComponent },
	{ path: 'login', component: LoginComponent },
];

@NgModule({
   declarations: [
      AppComponent,
      LoginComponent,
      MainComponent
   ],
   imports: [
      BrowserModule,
      FormsModule,
	   HttpModule,
	   RouterModule.forRoot(
		   appRoutes,
		   { enableTracing: true } 
	   )
   ],
   providers: [AccountService ],
   bootstrap: [AppComponent]
})
export class AppModule { }