import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CouponService {


  baseurl = 'http://localhost:5000/api/coupon/';
  constructor(private http: HttpClient) { }

  // add coupon
  create(model: any) {
    return this.http.post(this.baseurl + 'create', model);
  }

}
