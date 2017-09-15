import { NgModule, APP_INITIALIZER } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { HeroDetailsModule } from "./hero-details/hero-details.module";

import { AppComponent } from './app.component';
import { HeroesComponent } from "./heroes/heroes.component";
import { Dashboard } from './dashboard/dashboard.component'

import { routing } from './app.routing';
import { Config } from './config';

export function configLoader(config: Config): any {
    return () => config.load('development');
}

@NgModule({
    imports: [BrowserModule, routing, HttpModule, HeroDetailsModule],
    declarations: [AppComponent, Dashboard, HeroesComponent],
    providers: [
        Config,
        {
            provide: APP_INITIALIZER,
            useFactory: configLoader,
            deps: [Config],
            multi: true
        }
    ],
    bootstrap: [AppComponent]
})

export class AppModule {}