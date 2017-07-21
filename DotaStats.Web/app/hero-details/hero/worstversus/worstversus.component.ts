import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

import { HeroesService } from '../../hero-details.service';
import { Hero, WorstVersus } from "../../hero-details.models";
import { LoadingPage } from "../../../loading-indicator/loading-indicator";

@Component({
    selector: 'worstversus',
    templateUrl: 'app/hero-details/hero/worstversus/worstversus.template.html',
    styleUrls: ['app/hero-details/hero/worstversus/worstversus.css']
})

export class WorstVersusComponent extends LoadingPage implements OnInit, OnChanges {
    @Input() currentHero: Hero;
    worstVersus: WorstVersus[];

    constructor(private _heroesService: HeroesService) {
        super(true);
    }

    ngOnInit() {
        this.getWorstVersus(this.currentHero.hero_id);
    }

    ngOnChanges(changes: { [propName: string]: SimpleChange }) {
        this.currentHero = changes['currentHero'].currentValue;

        if (!changes['currentHero'].isFirstChange()) {
            this.standby();
            this.getWorstVersus(this.currentHero.hero_id);
        }
    }

    getWorstVersus(id: number) {
        this._heroesService.getWorstVersus(id)
            .subscribe(worstVersus => {
                this.worstVersus = worstVersus;
                this.ready();
            });
    }
}