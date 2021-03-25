import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Words } from './words';
import { environment } from 'src/environments/environment';

@Injectable({providedIn: 'root'})
export class WordsService {
  private apiServerUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient){}

  public getWords(): Observable<string[]> {
    return this.http.get<string[]>(`${this.apiServerUrl}/word/all`);
  }

  public getList(): Observable<string[]> {
    return this.http.get<string[]>(`${this.apiServerUrl}/word/nochange`);
  }

  public addWords(svalue: string): Observable<string[]> {
    return this.http.post<string[]>(`${this.apiServerUrl}/word/add`, svalue);
  }
}