import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Colaborador } from '../models/Colaborador';

@Injectable()
export class ColaboradorService {
  baseUrl = 'https://localhost:5001/api/colaborador';
  constructor(private http: HttpClient) {}

  public getColaboradores(): Observable<Colaborador[]> {
    return this.http.get<Colaborador[]>(this.baseUrl);
  }

  public getColaboradoresByNome(nome: string): Observable<Colaborador[]> {
    return this.http.get<Colaborador[]>(`${this.baseUrl}/nome/${nome}`);
  }

  public getColaboradorById(id: number): Observable<Colaborador> {
    return this.http.get<Colaborador>(`${this.baseUrl}/${id}`);
  }
}
