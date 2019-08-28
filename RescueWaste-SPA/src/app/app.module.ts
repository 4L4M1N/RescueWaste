import { BrowserModule, Title } from '@angular/platform-browser'; // For Title Service
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap';
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
      ManagerComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AuthService,
      AuthGuard,
      ErrorInterceptorProvider,
      AlertifyService,
      Title//ForTitleService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
