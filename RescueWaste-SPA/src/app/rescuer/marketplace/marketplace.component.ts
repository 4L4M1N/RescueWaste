import { Component, OnInit } from '@angular/core';
import { Promocode } from 'src/app/_models/Promocode';
import { PromocodeService } from 'src/app/services/promocode.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';

@Component({
  selector: 'app-marketplace',
  templateUrl: './marketplace.component.html',
  styleUrls: ['./marketplace.component.css']
})

export class MarketplaceComponent implements OnInit {
  promocodes: Promocode[];
  pagination: Pagination;
  constructor(private promocodeService: PromocodeService,
              private alertify: AlertifyService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.promocodes = data['promocodes'].result;
      this.pagination = data['promocodes'].pagination;
      console.log(this.promocodes);
    });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadPromocode();
  }

  loadPromocode()
  {
    this.promocodeService.getPromocodes(this.pagination.currentPage, this.pagination.itemsPerPage)
    .subscribe(
      (res: PaginatedResult<Promocode[]>) => {
      this.promocodes = res.result;
      this.pagination = res.pagination;
    }, error => {
      this.alertify.error(error);
    });
  }

}
