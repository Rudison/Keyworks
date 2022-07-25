import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SituacaoCard } from '../models/SituacaoCard';

@Injectable()
export class SituacaoCardService {
  baseUrl = 'https://localhost:5001/api/situacaoCard';
  constructor(private http: HttpClient) {}

  public getSituacaoCards(): Observable<SituacaoCard[]> {
    return this.http.get<SituacaoCard[]>(this.baseUrl);
  }

  public getSituacaoCardsByDescricao(
    descricao: string
  ): Observable<SituacaoCard[]> {
    return this.http.get<SituacaoCard[]>(
      `${this.baseUrl}/descricao/${descricao}`
    );
  }

  public getSituacaoCardById(id: number): Observable<SituacaoCard> {
    return this.http.get<SituacaoCard>(`${this.baseUrl}/${id}`);
  }
}
