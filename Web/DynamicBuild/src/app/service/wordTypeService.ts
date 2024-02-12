import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { wordType } from '../core/shared/models/wordType';
import { Observable } from 'rxjs';
import { ApiResponse } from '../core/model';
import { environment } from '../../environments/environment.development';

@Injectable()
export class wordTypeService {
    baseUrl = environment.apiUrl;
    constructor(private http: HttpClient) {}
    
      getwordTypes(): Observable<ApiResponse<wordType>> {
        return this.http.get<ApiResponse<wordType>>(this.baseUrl + 'WordTypes');
      }
};