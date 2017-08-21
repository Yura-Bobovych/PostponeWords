import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { WordService } from '../services/word.service'

@Component({
	selector: 'search',
	templateUrl: './search.component.html',
	styleUrls: ['./search.component.css']
})
export class SearchComponent {
	searched = false
	responTest = "";
	constructor(private wordService: WordService) { }
    
	onSubmit(form: NgForm) {
		
		this.wordService.searchWord(form.value.search_text).subscribe(res => {
			this.searched = true;
			this.responTest = "";
			this.responTest = res.text();
			console.log(res);
			console.log(res.text());
		});
}
}
