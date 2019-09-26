import {Injectable} from '@angular/core';
import {Promocode} from '../_models/Promocode';
import {Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import { PromocodeService } from '../services/promocode.service';
import { AlertifyService } from '../services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
@Injectable()
export class PromoCodeListResolver implements Resolve<Promocode[]> {
    pageNumber = 1;
    pageSize = 6;
    constructor(private promocodeService: PromocodeService,
                private router: Router, private alertify: AlertifyService) {}

        resolve(route: ActivatedRouteSnapshot) : Observable<Promocode[]> {
            return this.promocodeService.getPromocodes(this.pageNumber, this.pageSize).pipe (
                catchError(error => {
                    this.alertify.error('Problem Retrieving Data');
                    this.router.navigate(['/rescuer']);
                    return of(null);
                })
            );
        }
}
