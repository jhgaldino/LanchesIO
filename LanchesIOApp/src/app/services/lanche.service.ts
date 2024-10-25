// src/app/services/lanche.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Ingrediente {
  id: number;
  nome: string;
  valor: number;
}

export interface Lanche {
  id: number;
  nome: string;
  ingredientes: Ingrediente[];
  valor: number;
}

export interface LoginResponse {
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class LancheService {
  private readonly apiUrl = 'http://localhost:5103/api/lanches';
  private readonly authUrl = 'http://localhost:5103/api/auth';

  constructor(private readonly http: HttpClient) {}

  getLanches(): Observable<Lanche[]> {
    return this.http.get<Lanche[]>(this.apiUrl);
  }

  login(username: string, password: string): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.authUrl}/login`, { username, password });
  }
}
