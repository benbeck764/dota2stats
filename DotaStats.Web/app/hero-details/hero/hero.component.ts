import { Component, Input, OnChanges, SimpleChange } from '@angular/core';

import { HeroesService } from '../hero-details.service';
import { Hero } from "../hero-details.models";

@Component({
    selector: 'hero',
    templateUrl: 'app/hero-details/hero/hero.template.html',
    providers: [HeroesService],
    styleUrls: ['app/hero-details/hero/hero.css']
})
export class HeroComponent implements OnChanges {

    @Input() currentHero: Hero;

    heroImgSrc: string;

    ngOnChanges(changes: { [propName: string]: SimpleChange }) {
        this.currentHero = changes['currentHero'].currentValue;
        this.heroImgSrc = `/public/images/heroes_vert/${this.currentHero.name}.jpg`;
    }
}