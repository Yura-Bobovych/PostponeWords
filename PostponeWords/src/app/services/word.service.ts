import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
@Injectable()
export class WordService {

	constructor(private httpService: Http) { }

	searchWord(word: string): Observable<Response> {
		let headers = new Headers();
		headers.append('Content-Type', 'application/json');
		let authToken = localStorage.getItem('auth_token');
		headers.append('Authorization', `Bearer ${authToken}`);
		return this.httpService.get('api/words/meaning', { headers, params: { "word": word } })
			
			
	}

}
