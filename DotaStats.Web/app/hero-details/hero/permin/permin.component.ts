import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

import { HeroesService } from '../../hero-details.service';
import { Hero, PerMin } from "../../hero-details.models";
import { LoadingPage } from "../../../loading-indicator/loading-indicator";

@Component({
    selector: 'permin',
    templateUrl: 'app/hero-details/hero/permin/permin.template.html',
    styleUrls: ['app/hero-details/hero/permin/permin.css']
})

export class PerMinComponent extends LoadingPage implements OnInit, OnChanges {
    @Input() currentHero: Hero;
    permin: PerMin;

    constructor(private _heroesService: HeroesService) {
        super(true);
    }

    ngOnInit() {
        this.getPerMin(this.currentHero.hero_id);
    }

    ngOnChanges(changes: { [propName: string]: SimpleChange }) {
        this.currentHero = changes['currentHero'].currentValue;

        if (!changes['currentHero'].isFirstChange()) {
            this.standby();
            this.getPerMin(this.currentHero.hero_id);
        }
    }

    getPerMin(id: number) {
        this._heroesService.getPerMin(id)
            .subscribe(permin => {
                this.permin = permin;
                this.ready();
            });
    }
}