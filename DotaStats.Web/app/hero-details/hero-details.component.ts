import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { HeroesService } from "./hero-details.service";
import { Hero } from "./hero-details.models";

@Component({
    selector: 'herodetails',
    templateUrl: '/app/hero-details/hero-details.template.html',
    providers: [HeroesService],
    styleUrls: ['app/hero-details/hero-details.css']
    
})
export class HeroDetailsComponent implements OnInit {
    heroes: Hero[];
    currentHero: Hero;

    constructor(private _heroesService: HeroesService) {}

    ngOnInit() {
        this.getHeroes();
        this.selectHero(1);
    }

    getHeroes() {
        this.heroes = [];
        this._heroesService.getHeroes()
            .subscribe(heroes => this.heroes = heroes);
    }

    selectHero(id: number) {
        for (let i = 0; i < this.heroes.length; i++) {
            if (this.heroes[i].hero_id === id) {
                this.currentHero = this.heroes[i];
            }
        }
    }
}