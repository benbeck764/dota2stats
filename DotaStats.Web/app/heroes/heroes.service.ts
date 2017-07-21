import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

import {HeroRecord} from "./heroes.models";

@Injectable()
export class HeroRecordsService {

    private accountId = 111871881;
    private heroRecordsUrl = "http://localhost:58064/api/herorecords/all";

    constructor(private _http: Http) { }

    getHeroRecords(): Observable<HeroRecord[]> {
        return this._http.get(this.heroRecordsUrl + "?accountId=" + this.accountId)
            .map(heroRecords => heroRecords.json() as HeroRecord[])
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}