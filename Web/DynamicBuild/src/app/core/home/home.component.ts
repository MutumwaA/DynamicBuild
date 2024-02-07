import { Component, OnInit } from '@angular/core';
import { ApiResponse, Pagination, Sentence, Word, WordDropdownItem, WordTypeDropdownItem } from '../model';
import { sentenceService } from '../../service/sentenceService';
import { wordService } from '../../service/wordService';
import { wordTypeService } from '../../service/wordTypeService';
import { wordType } from '../shared/models/wordType';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

sentences: Sentence[] = [];
first = 1;
rows = 10;
currentPage: number = 0;
itemsPerPage: number = 0;
totalPages: number = 0;

reset() {
  console.log(this.first);
  this.first = 1;
  this.fetchSubmittedSentences();
}

pageChange(event: { first: number; rows: number; }) {
  this.rows = event.rows;
}

isLastPage(): boolean {
  return this.sentences ? this.first + this.rows >= this.sentences.length : true;
}

isFirstPage(): boolean {
  return this.first === 1;
}

  selectedWord: any = '';
  sentence: string = '';

  wordTypeDropdownItems: WordTypeDropdownItem[] = [];
  wordDropdownItems: WordDropdownItem[] = [];
  pagination: Pagination | undefined;
  totalRecords: number = 0;
  currentPageReportTemplate: string = 'Showing {first} to {last} of {totalRecords} entries';


  constructor(
    private _sentenceService: sentenceService,
    private _wordService: wordService,
    private _wordTypeService: wordTypeService,
    ) {}

  ngOnInit() {
     this.fetchWordsType();
     this.fetchSubmittedSentences();
  }

  fetchWordsType() {
    this._wordTypeService.getwordTypes().subscribe((response: ApiResponse<wordType>) => {
      if (response.isSuccess && response.value) {
        response.value.forEach((wordType: wordType) => {
          this.wordTypeDropdownItems.push({
            code: wordType.id,
            name: wordType.type
          });
        });
      } else {
        console.error('Error fetching word types:', response.error);
      }
    });
  }

  onTypeChange(event: any): void {
    this._wordService.getWordsBywordType(event.value.code).subscribe((response: ApiResponse<Word>) => {
      if (response.isSuccess && response.value) {
        this.wordDropdownItems = []
        response.value.forEach((word: Word) => {
          this.wordDropdownItems.push({
            code: word.id,
            name: word.value
          });
        });
      } else {
        console.error('Error fetching words by word type:', response.error);
      }
    });
    
  }

  onSubmit(): void {
  }

  addWord() {
    this.sentence += this.selectedWord?.name + ' ';
  }

  submitSentence() {
    const newSentence: Sentence = { content: this.sentence };
    this._sentenceService.createSentences(newSentence).subscribe(() => {
      this.sentence = '';
      this.fetchSubmittedSentences();
    });
  }

  fetchSubmittedSentences() {
    this._sentenceService.getSentences(this.first, this.rows).subscribe({
      next: response => {
         this.sentences = response.result;
         this.pagination = response.pagination;
         this.totalRecords = this.pagination?.totalItems || 0;
         this.currentPage = this.pagination?.currentPage || 0;
         this.itemsPerPage = this.pagination?.itemsPerPage || 0;
         this.totalPages = this.pagination?.totalPages || 0;

        const firstEntry = (this.currentPage  - 1) * this.itemsPerPage + 1;
        const lastEntry = Math.min(this.currentPage  * this.itemsPerPage,  this.totalRecords);
        this.currentPageReportTemplate = `Showing ${firstEntry} to ${lastEntry} of ${this.totalRecords} entries`;
      }
    })
  }
}
