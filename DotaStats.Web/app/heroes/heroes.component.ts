import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import {HeroRecord} from "./heroes.models";
import {HeroRecordsService} from "./heroes.service";

@Component({
    selector: 'heroes',
    templateUrl: '/app/heroes/heroes.template.html',
    providers: [HeroRecordsService],
    styleUrls: ['app/heroes/heroes.css']

})
export class HeroesComponent implements OnInit {

    heroRecords: HeroRecord[];

    constructor(private _heroRecordsService: HeroRecordsService) { }

    ngOnInit() {
        this.getHeroRecords();
    }

    getHeroRecords() {
        this.heroRecords = [];
        this._heroRecordsService.getHeroRecords()
            .subscribe(heroRecords => this.heroRecords = heroRecords);
    }
}