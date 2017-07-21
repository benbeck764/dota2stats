import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

import { HeroesService } from '../../hero-details.service';
import { Hero, LastHitsDenies } from "../../hero-details.models";
import { LoadingPage } from "../../../loading-indicator/loading-indicator";

@Component({
    selector: 'lhdeny',
    templateUrl: 'app/hero-details/hero/lhdeny/lhdeny.template.html',
    styleUrls: ['app/hero-details/hero/lhdeny/lhdeny.css']
})

export class LastHitsDeniesComponent extends LoadingPage implements OnInit, OnChanges {
    @Input() currentHero: Hero;
    lhdeny: LastHitsDenies;

    constructor(private _heroesService: HeroesService) {
        super(true);
    }

    ngOnInit() {
        this.getLastHitsAndDenies(this.currentHero.hero_id);
    }

    ngOnChanges(changes: { [propName: string]: SimpleChange }) {
        this.currentHero = changes['currentHero'].currentValue;

        if (!changes['currentHero'].isFirstChange()) {
            this.standby();
            this.getLastHitsAndDenies(this.currentHero.hero_id);
        }
    }

    getLastHitsAndDenies(id: number) {
        this._heroesService.getLastHitsAndDenies(id)
            .subscribe(lhdeny => {
                this.lhdeny = lhdeny;
                this.ready();
            });
    }
}