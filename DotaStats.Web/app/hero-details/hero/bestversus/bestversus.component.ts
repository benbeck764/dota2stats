import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

import { HeroesService } from '../../hero-details.service';
import { Hero, BestVersus } from "../../hero-details.models";
import { LoadingPage } from "../../../loading-indicator/loading-indicator";

@Component({
    selector: 'bestversus',
    templateUrl: 'app/hero-details/hero/bestversus/bestversus.template.html',
    styleUrls: ['app/hero-details/hero/bestversus/bestversus.css']
})

export class BestVersusComponent extends LoadingPage implements OnInit, OnChanges {
    @Input() currentHero: Hero;
    bestVersus: BestVersus[];

    constructor(private _heroesService: HeroesService) {
        super(true);
    }

    ngOnInit() {
        this.getBestVersus(this.currentHero.hero_id);
    }

    ngOnChanges(changes: { [propName: string]: SimpleChange }) {
        this.currentHero = changes['currentHero'].currentValue;

        if (!changes['currentHero'].isFirstChange()) {
            this.standby();
            this.getBestVersus(this.currentHero.hero_id);
            console.log('bestVersus: ' + JSON.stringify(this.bestVersus));
        }
    }

    getBestVersus(id: number) {
        this._heroesService.getBestVersus(id)
            .subscribe(bestVersus => {
                this.bestVersus = bestVersus;
                this.ready();
            });
    }
}