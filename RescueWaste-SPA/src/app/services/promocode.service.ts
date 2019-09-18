import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Promocode } from '../_models/Promocode';

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
  getPromocodes(): Observable<Promocode[]> {
    return this.http.get<Promocode[]>(this.baseurl);
  }

}
