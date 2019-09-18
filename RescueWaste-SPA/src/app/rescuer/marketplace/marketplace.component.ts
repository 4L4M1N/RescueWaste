import { Component, OnInit } from '@angular/core';
import { Promocode } from 'src/app/_models/Promocode';
import { PromocodeService } from 'src/app/services/promocode.service';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-marketplace',
  templateUrl: './marketplace.component.html',
  styleUrls: ['./marketplace.component.css']
})
export class MarketplaceComponent implements OnInit {
  promocodes: Promocode[];
  constructor(private promocodeService: PromocodeService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadPromocode();
  }
  loadPromocode()
  {
    this.promocodeService.getPromocodes().subscribe((promocodes: Promocode[]) => {
      this.promocodes = promocodes;
    }, error => {
      this.alertify.error(error);
    });
  }

}
