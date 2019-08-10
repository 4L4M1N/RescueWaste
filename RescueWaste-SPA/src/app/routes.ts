import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { GUserDashboardComponent } from './gUserDashboard/gUserDashboard.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'gUserDashboard', component: GUserDashboardComponent, canActivate: [AuthGuard]},
        ]
    },
    { path: 'register', component: RegisterComponent},

    { path: '**', redirectTo: '', pathMatch: 'full'},
];
