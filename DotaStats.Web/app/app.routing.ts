import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Dashboard } from './dashboard/dashboard.component'
import { HeroDetailsComponent } from "./hero-details/hero-details.component";
import { HeroesComponent } from "./heroes/heroes.component";

const appRoutes: Routes = [
    {
        path: '',
        component: Dashboard
    },
    {
        path: 'heroes',
        component: HeroesComponent
    },
    {
        path: 'herodetails',
        component: HeroDetailsComponent
    },
    {
        path: '**',  // otherwise route.
        component: Dashboard
    }
];


export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);