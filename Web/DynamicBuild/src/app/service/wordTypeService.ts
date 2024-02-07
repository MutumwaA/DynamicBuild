import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { wordType } from '../core/shared/models/wordType';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { ApiResponse } from '../core/model';

@Injectable()
export class wordTypeService {
    baseUrl = environment.apiUrl;
    constructor(private http: HttpClient) {}
    
    // getwordTypes() {
    //     return this.http.get<wordType[]>(this.baseUrl + 'WordTypes');
    //}
      getwordTypes(): Observable<ApiResponse<wordType>> {
        return this.http.get<ApiResponse<wordType>>(this.baseUrl + 'WordTypes');
      }
};