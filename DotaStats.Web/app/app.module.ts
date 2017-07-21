import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { HeroDetailsModule } from "./hero-details/hero-details.module";


import { AppComponent } from './app.component';
import { HeroesComponent } from "./heroes/heroes.component";

import { Dashboard } from './dashboard/dashboard.component'

import { routing } from './app.routing';

@NgModule({
    imports: [BrowserModule, routing, HttpModule, HeroDetailsModule],
    declarations: [AppComponent, Dashboard, HeroesComponent],
    bootstrap: [AppComponent]
})

export class AppModule {}