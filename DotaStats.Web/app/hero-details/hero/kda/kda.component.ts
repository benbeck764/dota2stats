import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

import { HeroesService } from "../../hero-details.service";
import { Hero, KDA } from "../../hero-details.models";
import {LoadingPage} from "../../../loading-indicator/loading-indicator";

@Component({
    selector: 'kda',
    templateUrl: 'app/hero-details/hero/kda/kda.template.html',
    styleUrls: ['app/hero-details/hero/kda/kda.css']
})
export class KdaComponent extends LoadingPage implements OnInit, OnChanges {
    @Input() currentHero: Hero;
    kda: KDA;

    constructor(private _heroesService: HeroesService) {
        super(true);
    }

    ngOnInit() {
        this.getKDA(this.currentHero.hero_id);
    }

    ngOnChanges(changes: { [propName: string]: SimpleChange }) {
        this.currentHero = changes['currentHero'].currentValue;

        if (!changes['currentHero'].isFirstChange()) {
            this.standby();
            this.getKDA(this.currentHero.hero_id);
        }
    }

    getKDA(heroId: number) {
        this._heroesService.getKDA(heroId)
            .subscribe(kda => {
                this.kda = kda;
                this.ready();
            });
    }
}

