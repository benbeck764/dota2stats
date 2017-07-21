import { Component, Input, OnInit, OnChanges, SimpleChange } from '@angular/core';

import { HeroesService } from '../../hero-details.service';
import { Hero, MostUsedItems } from "../../hero-details.models";
import {LoadingPage} from "../../../loading-indicator/loading-indicator";

@Component({
    selector: 'mostuseditems',
    templateUrl: 'app/hero-details/hero/items/items.template.html',
    styleUrls: ['app/hero-details/hero/items/items.css']
})

export class MostUsedItemsComponent extends LoadingPage implements OnInit, OnChanges {
    @Input() currentHero: Hero;
    mostUsed: MostUsedItems[];

    constructor(private _heroesService: HeroesService) {
        super(true);
    }

    ngOnInit() {
        this.getMostUsedItems(this.currentHero.hero_id);
    }

    ngOnChanges(changes: { [propName: string]: SimpleChange }) {
        this.currentHero = changes['currentHero'].currentValue;

        if (!changes['currentHero'].isFirstChange()) {
            this.standby();
            this.getMostUsedItems(this.currentHero.hero_id);
        }
    }

    getMostUsedItems(id: number) {
        this._heroesService.getMostUsedItems(id)
            .subscribe(mostUsed => {
                this.mostUsed = mostUsed;
                this.ready();
            });
    }
}