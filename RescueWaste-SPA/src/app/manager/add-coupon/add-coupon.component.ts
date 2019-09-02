import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-add-coupon',
  templateUrl: './add-coupon.component.html',
  styleUrls: ['./add-coupon.component.css']
})
export class AddCouponComponent implements OnInit {

  datePickerConfig: Partial<BsDatepickerConfig>;
  model: any = {};
  merchants: any;
  constructor(private http: HttpClient) {
    this.datePickerConfig = Object.assign({}, { minDate: new Date(Date.now())});
   }

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
