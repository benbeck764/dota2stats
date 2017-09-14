import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HeroDetailsComponent } from "./hero-details/hero-details.component";
import { HeroesComponent } from "./heroes/heroes.component";
import { AppComponent } from "./app.component";

const appRoutes: Routes = [
    {
        path: '',
        component: AppComponent
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
        component: AppComponent
    }
];


export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);