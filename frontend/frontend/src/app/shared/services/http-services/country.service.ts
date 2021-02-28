import {Injectable} from '@angular/core';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Country} from '../../models/country.model';
import {JsonObject} from "@angular/compiler-cli/ngcc/src/packages/entry_point";

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  private baseURL = 'api/countries';

  constructor(private httpClient: HttpClient) {}

  public getAll(): Observable<HttpResponse<Country[]>> {
    return this.httpClient.get<Country[]>(`${this.baseURL}/get/all`, {observe: 'response'});
  }

  public getAllWithPopulations(): Observable<HttpResponse<any[]>> {
    return this.httpClient.get<any[]>(`${this.baseURL}/get/all-populations`, {observe: 'response'});
  }

  public getAllWithUpdatedPopulations(): Observable<HttpResponse<any[]>> {
    return this.httpClient.get<any[]>(`${this.baseURL}/get/updated-populations`, {observe: 'response'});
  }

  public getById(id: number): Observable<HttpResponse<Country>> {
    return this.httpClient.get(`${this.baseURL}/get/${id}`, {observe: 'response'});
  }

  public create(country: Country): Observable<HttpResponse<Country>> {
    return this.httpClient.post(`${this.baseURL}/create`, country, {observe: 'response'});
  }

  public update(country: Country): Observable<HttpResponse<Country>> {
    return this.httpClient.put(`${this.baseURL}/update`, country, {observe: 'response'});
  }

  public deleteById(id: number): Observable<HttpResponse<Country>> {
    return this.httpClient.delete(`${this.baseURL}/delete/${id}`, {observe: 'response'});
  }
}
