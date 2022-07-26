import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PainelCard } from '../models/PainelCard';

@Injectable()
export class PainelCardsService {
  baseUrl = 'https://localhost:5001/api/painelCard';
  constructor(private http: HttpClient) {}

  public getPaineisCard(situacaoId: number): any {
    return this.http.get<any>(`${this.baseUrl}/situacao/${situacaoId}`);
  }

  public getPainelCardsBySituacao(
    situacaoId: number
  ): Observable<PainelCard[]> {
    return this.http.get<PainelCard[]>(
      `${this.baseUrl}/situacao/${situacaoId}`
    );
  }

  public getPainelCardById(id: number): Observable<PainelCard> {
    return this.http.get<PainelCard>(`${this.baseUrl}/${id}`);
  }
}
