import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guards/auth.guard';
import { RescuerComponent } from './rescuer/rescuer.component';
import { DashboardComponent } from './rescuer/dashboard/dashboard.component';
import { MarketplaceComponent } from './rescuer/marketplace/marketplace.component';
import { ManagerComponent } from './manager/manager.component';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'rescuer', component: RescuerComponent, canActivate: [AuthGuard], children : [
                {path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard]},
                {path: 'marketplace', component: MarketplaceComponent, canActivate: [AuthGuard]}
            ]},
        ]
    },
    { path: 'register', component: RegisterComponent},
    { path: 'manager', component: ManagerComponent, canActivate: [AuthGuard], data: {role: 'Manager'}},
    { path: '**', redirectTo: '', pathMatch: 'full'},
];
