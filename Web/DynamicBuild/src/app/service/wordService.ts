import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiResponse, Word } from '../core/model';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable()
export class wordService {
    baseUrl = environment.apiUrl;
    constructor(private http: HttpClient) {}
   
    getWordsBywordType(wordTypeId: string): Observable<ApiResponse<Word>> {
        const url = `${this.baseUrl}Words?WordTypeId=${wordTypeId}`;
        return this.http.get<ApiResponse<Word>>(url);
      }
};