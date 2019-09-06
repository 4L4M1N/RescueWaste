import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { AuthService } from 'src/app/services/auth.service';
import { PromocodeService } from 'src/app/services/promocode.service';

@Component({
  selector: 'app-add-coupon',
  templateUrl: './add-coupon.component.html',
  styleUrls: ['./add-coupon.component.css']
})
export class AddCouponComponent implements OnInit {

  datePickerConfig: Partial<BsDatepickerConfig>;
  model: any = {merchantId: -1};
  selected: any;
  merchants: any;
  constructor(private http: HttpClient, private promocodeService: PromocodeService, private authService: AuthService) {
    this.datePickerConfig = Object.assign({}, { minDate: new Date(Date.now())});
   }

  ngOnInit() {
    this.getMerchants();
  }

  getMerchants() {
    this.http.get('http://localhost:5000/api/promocode').subscribe(response => {
      this.merchants = response;
      console.log(this.merchants);
    }, error => {
      console.log(error);
    });
  }

  addCupon() {
    this.model.areaManagerId = this.authService.decodedToken.nameid;
    this.promocodeService.create(this.model).subscribe(() => {
      console.log('Promocode added');
    }, error => {
      console.log(error);
    });
    console.log(this.model);
  }

}
