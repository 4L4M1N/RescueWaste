import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { AuthService } from 'src/app/services/auth.service';
import { PromocodeService } from 'src/app/services/promocode.service';
import { FormGroup, FormControl } from '@angular/forms';
import { NgNoValidate } from '@angular/forms/src/directives/ng_no_validate_directive';

@Component({
  selector: 'app-add-coupon',
  templateUrl: './add-coupon.component.html',
  styleUrls: ['./add-coupon.component.css']
})
export class AddCouponComponent implements OnInit {

  datePickerConfig: Partial<BsDatepickerConfig>;
  model: any = {merchantId: -1};
  selected: any;
  file: any;
  filename: any;
  merchants: any;
  public imagePath;
  imgURL: any;
  couponForm: FormGroup;
  constructor(private http: HttpClient, private promocodeService: PromocodeService, private authService: AuthService) {
    this.datePickerConfig = Object.assign({}, { minDate: new Date(Date.now())});
   }

  ngOnInit() {
    this.getMerchants();
    this.filename = 'Choose image';
    this.couponForm = new FormGroup({
      name: new FormControl(),
      merchantId: new FormControl(),
      expiredDate: new FormControl(),
      file: new FormControl(),
      discount: new FormControl(),
      coinsRequired: new FormControl(),
      areaManagerId: new FormControl(-1)
    });



  }
  getMerchants() {
    this.http.get('http://localhost:5000/api/promocode/merchants').subscribe(response => {
      this.merchants = response;
      console.log(this.merchants);
    }, error => {
      console.log(error);
    });
  }
  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }
    this.file = <File>files[0];
    this.filename = this.file.name;
    var reader = new FileReader();
    this.imagePath = files;
    reader.readAsDataURL(files[0]);
    reader.onload = (_event) => {
      this.imgURL = reader.result;
    }
  }

  addCupon() {
    this.couponForm.controls['areaManagerId'].setValue(this.authService.decodedToken.nameid);
    const formData = new FormData();
    formData.append('file', this.file);

    const merchants = this.couponForm.controls['merchantId'].value;
    formData.append('merchantId', merchants);

    const name = this.couponForm.controls['name'].value;
    formData.append('name', name);

    const expiredDate = this.couponForm.controls['expiredDate'].value;
    formData.append('expiredDate', expiredDate);

    const areaManagerId = this.couponForm.controls['areaManagerId'].value;
    formData.append('areaManagerId', areaManagerId);

    const coinsRequired = this.couponForm.controls['coinsRequired'].value;
    formData.append('coinsRequired', coinsRequired);

    const discount = this.couponForm.controls['discount'].value;
    formData.append('discount', discount);

    // formData.append('merchantname', this.couponForm.controls['profile'].value);
    // formData.append('name', this.couponForm.controls['merchantname'].value);
    // formData.append('expireDate', this.couponForm.controls['expireDate'].value);
    // formData.append('areaManagerId', this.couponForm.controls['areaManagerId'].value);
    let values = this.couponForm.value;
    this.promocodeService.create(formData).subscribe(() => {
      console.log('Promocode added');
    }, error => {
      console.log(error);
    });

    console.log(merchants);
    console.log(this.couponForm.controls['name'].value);

  }

}
