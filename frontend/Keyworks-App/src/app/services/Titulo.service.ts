import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Titulo } from '../models/Titulo';

@Injectable()
export class TituloService {
  baseUrl = 'https://localhost:5001/api/titulo';
  constructor(private http: HttpClient) {}

  public getTitulos(): Observable<Titulo[]> {
    return this.http.get<Titulo[]>(this.baseUrl);
  }

  public getTitulosByDescricao(descricao: string): Observable<Titulo[]> {
    return this.http.get<Titulo[]>(`${this.baseUrl}/descricao/${descricao}`);
  }

  public getTituloById(id: number): Observable<Titulo> {
    return this.http.get<Titulo>(`${this.baseUrl}/${id}`);
  }
}
