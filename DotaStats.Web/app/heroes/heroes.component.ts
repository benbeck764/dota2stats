import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { HeroRecord } from "./heroes.models";
import { HeroRecordsService } from "./heroes.service";
//import { DataTable, DataTableTranslations, DataTableResource } from 'angular-4-data-table';

@Component({
    selector: 'heroes',
    templateUrl: '/app/heroes/heroes.template.html',
    providers: [HeroRecordsService],
    styleUrls: ['app/heroes/heroes.css']

})
export class HeroesComponent implements OnInit {

    heroRecords: HeroRecord[];
    //itemResource = new DataTableResource(this.heroRecords);
    //items = [];
    //itemCount = 0;

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