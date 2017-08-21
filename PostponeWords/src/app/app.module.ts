import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ModuleWithProviders } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { MainComponent } from './main/main.component';
import { AccountService } from "./services/account.service"
import { AuthGuard } from "./services/auth-guard.service";
import { SearchComponent } from './search/search.component';
import { IndexComponent } from './index/index.component';
import { WordService} from './services/word.service'


const appRoutes: Routes = [
	{ path: '', component: IndexComponent},
	{ path: 'login', component: LoginComponent },
	{ path: 'main', component: MainComponent, canActivate: [AuthGuard]  }
];

@NgModule({
   declarations: [
      AppComponent,
      LoginComponent,
      MainComponent,
      SearchComponent,
      IndexComponent
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
   providers: [AccountService, AuthGuard, WordService],
   bootstrap: [AppComponent]
})
export class AppModule { }