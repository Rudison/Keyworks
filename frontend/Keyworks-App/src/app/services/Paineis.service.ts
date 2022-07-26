import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class PaineisService {
  baseUrl = 'https://localhost:5001/api/painel';
  constructor(private http: HttpClient) {}

  public getPaineis(): any {
    return this.http.get<any>(this.baseUrl);
  }
}
