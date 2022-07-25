import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { StatusCard } from '../models/StatusCard';

@Injectable()
export class StatusCardService {
  baseUrl = 'https://localhost:5001/api/statusCard';
  constructor(private http: HttpClient) {}

  public getStatusCards(): Observable<StatusCard[]> {
    return this.http.get<StatusCard[]>(this.baseUrl);
  }

  public getStatusCardByDescricao(descricao: string): Observable<StatusCard[]> {
    return this.http.get<StatusCard[]>(
      `${this.baseUrl}/descricao/${descricao}`
    );
  }

  public getStatusCardById(id: number): Observable<StatusCard> {
    return this.http.get<StatusCard>(`${this.baseUrl}/${id}`);
  }
}
