import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ModuleWithProviders } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { MainComponent } from './main/main.component';
import { AccountService } from "./account.service"
import { AuthGuard } from "./auth-guard.service";


const appRoutes: Routes = [
	{ path: '', component: MainComponent, canActivate: [AuthGuard] },
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
   providers: [AccountService, AuthGuard],
   bootstrap: [AppComponent]
})
export class AppModule { }