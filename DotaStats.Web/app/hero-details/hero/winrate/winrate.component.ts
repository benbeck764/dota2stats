import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';
import { Hero, WinRate } from "../../hero-details.models";
import { HeroesService } from "../../hero-details.service";
import {LoadingPage} from "../../../loading-indicator/loading-indicator";

@Component({
    selector: 'winrate',
    templateUrl: 'app/hero-details/hero/winrate/winrate.template.html',
    styleUrls: ['app/hero-details/hero/winrate/winrate.css']
})

export class WinRateComponent extends LoadingPage implements OnInit, OnChanges{
    @Input() currentHero: Hero;
    winRate: WinRate;

    constructor(private _heroesService: HeroesService) {
        super(true);
    }

    ngOnInit() {
        this.winRate = this.getWinRate(this.currentHero.hero_id);
    }

    ngOnChanges(changes: { [propName: string]: SimpleChange }) {
        this.currentHero = changes['currentHero'].currentValue;

        if (!changes['currentHero'].isFirstChange()) {
            this.standby();
            this.winRate = this.getWinRate(this.currentHero.hero_id);
        }
    }

    getWinRate(id: number) {
        this._heroesService.getWinRate(id)
            .subscribe(winRate => {
                this.winRate = winRate;
                this.ready();
            });

        return this.winRate;
    }
}