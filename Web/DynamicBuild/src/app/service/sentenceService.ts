import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PaginatedResult, Sentence } from '../core/model';
import { Observable, map } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable()
export class sentenceService {
    baseUrl = environment.apiUrl;
    constructor(private http: HttpClient) {}

    getSentences(pageNumber: number, pageSize: number): Observable<any> {
        const url = `${this.baseUrl}Sentence?PageNumber=${pageNumber}&PageSize=${pageSize}`;
        // Set headers to observe response headers
        const options = {
          observe: 'response' as const // observe response headers
        };

        const paginatedResult: PaginatedResult<Sentence[]> = new PaginatedResult<Sentence[]>;
    
        return this.http.get<Sentence[]>(url, options)
          .pipe(
            map(response => {
    
              if (response.body) {
                paginatedResult.result = response.body;
              }
    
              const paginationHeader = response.headers.get('Pagination');
              if (paginationHeader) {
                const pagination = JSON.parse(paginationHeader);
                paginatedResult.pagination = pagination;
              }
              return paginatedResult;
            })
          );
      }
      createSentences(sentence: Sentence) {
        return this.http.post<Sentence>(this.baseUrl + 'Sentence', sentence);
      }   
};