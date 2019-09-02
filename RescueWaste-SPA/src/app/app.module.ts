import { BrowserModule, Title } from '@angular/platform-browser'; // For Title Service
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './services/auth.service';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { appRoutes } from './routes';
import { AuthGuard } from './_guards/auth.guard';
import { RescuerComponent } from './rescuer/rescuer.component';
import { ErrorInterceptor, ErrorInterceptorProvider } from './services/error.interceptor';
import { AlertifyService } from './services/alertify.service';
import { DashboardComponent } from './rescuer/dashboard/dashboard.component';
import { LeftNavComponent } from './rescuer/left-nav/left-nav.component';
import { MarketplaceComponent } from './rescuer/marketplace/marketplace.component';
import { ManagerComponent } from './manager/manager.component';
import { ManagerDashboardComponent } from './manager/manager-dashboard/manager-dashboard.component';
import { ManagerNavComponent } from './manager/manager-nav/manager-nav.component';
import { AddCouponComponent } from './manager/add-coupon/add-coupon.component';





@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      RegisterComponent,
      HomeComponent,
      RescuerComponent,
      DashboardComponent,
      LeftNavComponent,
      MarketplaceComponent,
      ManagerComponent,
      ManagerDashboardComponent,
      ManagerNavComponent,
      AddCouponComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      BrowserAnimationsModule,
      BsDatepickerModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AuthService,
      AuthGuard,
      ErrorInterceptorProvider,
      AlertifyService,
      Title// ForTitleService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
