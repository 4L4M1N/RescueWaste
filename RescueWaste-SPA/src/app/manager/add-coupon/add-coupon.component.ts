import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-coupon',
  templateUrl: './add-coupon.component.html',
  styleUrls: ['./add-coupon.component.css']
})
export class AddCouponComponent implements OnInit {

  model: any = {};
  merchants: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getMerchants();
  }

  getMerchants() {
    this.http.get('http://localhost:5000/api/coupon').subscribe(response => {
      this.merchants = response;
      console.log(this.merchants);
    }, error => {
      console.log(error);
    });
  }
  addCupon() {
    console.log(this.model);
  }

}
