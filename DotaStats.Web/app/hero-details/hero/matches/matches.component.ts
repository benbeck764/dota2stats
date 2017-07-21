import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

import { Hero, MatchDetails } from "../../hero-details.models";
import {LoadingPage} from "../../../loading-indicator/loading-indicator";
import { HeroesService } from "../../hero-details.service";

@Component({
    selector: 'matchdetails',
    templateUrl: 'app/hero-details/hero/matches/matches.template.html',
    styleUrls: ['app/hero-details/hero/matches/matches.css']
})

export class MatchesComponent extends LoadingPage implements OnInit, OnChanges {
    @Input() currentHero: Hero;
    details: MatchDetails[];

    constructor(private _heroesService: HeroesService) {
        super(true);
    }

    ngOnInit() {
        this.details = this.getMatchDetails(this.currentHero.hero_id);
    }

    ngOnChanges(changes: { [propName: string]: SimpleChange }) {
        this.currentHero = changes['currentHero'].currentValue;
        if (!changes['currentHero'].isFirstChange()) {
            this.standby();
            this.details = this.getMatchDetails(this.currentHero.hero_id);
        }
    }

    getMatchDetails(id: number) {
        this._heroesService.getMatchDetails(id)
            .subscribe(details => {
                this.details = details;
                this.ready();
            });

        return this.details;
    }
}