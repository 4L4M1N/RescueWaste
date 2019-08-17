import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guards/auth.guard';
import { RescuerComponent } from './rescuer/rescuer.component';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'rescuer', component: RescuerComponent, canActivate: [AuthGuard]},
        ]
    },
    { path: 'register', component: RegisterComponent},

    { path: '**', redirectTo: '', pathMatch: 'full'},
];
