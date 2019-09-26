import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Promocode } from '../_models/Promocode';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PromocodeService {

  baseurl = 'http://localhost:5000/api/promocode/';
  constructor(private http: HttpClient) { }

  // add coupon
  create(model: any) {
    return this.http.post(this.baseurl + 'create', model);
  }
  getPromocodes(page?, itemsPerPage?): Observable<PaginatedResult<Promocode[]>> {
    const paginatedResult: PaginatedResult<Promocode[]> = new PaginatedResult<Promocode[]>();
    let params = new HttpParams();
    if (page != null && itemsPerPage != null)
    {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }
    return this.http.get<Promocode[]>(this.baseurl, {observe: 'response', params})
    .pipe(
      map(response => {
        paginatedResult.result = response.body;
        if(response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return paginatedResult;
      })
    );
  }

}
