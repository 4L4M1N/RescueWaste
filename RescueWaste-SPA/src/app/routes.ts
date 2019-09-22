import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guards/auth.guard';
import { RescuerComponent } from './rescuer/rescuer.component';
import { DashboardComponent } from './rescuer/dashboard/dashboard.component';
import { MarketplaceComponent } from './rescuer/marketplace/marketplace.component';
import { ManagerComponent } from './manager/manager.component';
import { ManagerDashboardComponent } from './manager/manager-dashboard/manager-dashboard.component';
import { AddCouponComponent } from './manager/add-coupon/add-coupon.component';
import { AccountSettingsComponent } from './account-settings/account-settings.component';
import { GiveRewardsComponent } from './manager/give-rewards/give-rewards.component';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'rescuer', component: RescuerComponent, data: {role: 'Rescuer'}, canActivate: [AuthGuard], children : [
                {path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard]},
                {path: 'marketplace', component: MarketplaceComponent, canActivate: [AuthGuard]},
                {path: 'account-settings', component: AccountSettingsComponent, canActivate: [AuthGuard]}
            ]},
            { path: 'manager', component: ManagerComponent, data: {role: 'Manager'}, canActivate: [AuthGuard], children : [
                {path: 'manager-dashboard', component: ManagerDashboardComponent, canActivate: [AuthGuard]},
                {path: 'add-coupon', component: AddCouponComponent, canActivate: [AuthGuard]},
                {path: 'account-settings', component: AccountSettingsComponent, canActivate: [AuthGuard]},
                {path: 'give-rewards', component: GiveRewardsComponent, canActivate: [AuthGuard]}
            ]},
        ]
    },

    { path: 'register', component: RegisterComponent},
    {path: 'account-settings', component: AccountSettingsComponent, canActivate: [AuthGuard]},
    // {
    //      path: 'manager', component: ManagerComponent, canActivate: [AuthGuard], data: {role: 'Manager'},
    // },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];
