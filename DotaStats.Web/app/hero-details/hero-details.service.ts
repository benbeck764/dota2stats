import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

import { Hero, KDA, WinRate, MostUsedItems, MatchDetails, PerMin, LastHitsDenies, BestVersus, WorstVersus } from './hero-details.models';

@Injectable()
export class HeroesService {

    private accountId = 111871881;
    private heroesUrl = "http://localhost:58064/api/heroes/all";
    private kdaUrl = "http://localhost:58064/api/statistics/kda";
    private winRateUrl = "http://localhost:58064/api/statistics/winrate";
    private mostUsedItemsUrl = "http://localhost:58064/api/statistics/mostused";
    private matchDetailsUrl = "http://localhost:58064/api/statistics/matches";
    private perMinUrl = "http://localhost:58064/api/statistics/permin";
    private lastHitsDeniesUrl = "http://localhost:58064/api/statistics/lhdeny";
    private bestVersusUrl = "http://localhost:58064/api/statistics/bestversus";
    private worstVersusUrl = "http://localhost:58064/api/statistics/worstversus";

    constructor(private _http: Http) { }

    getHeroes(): Observable<Hero[]> {
        return this._http.get(this.heroesUrl)
            .map(heroes => heroes.json() as Hero[])
            .catch(this.handleError);
    }

    getKDA(heroId:number): Observable<KDA> {
        return this._http.get(this.kdaUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(kda => kda.json() as KDA)
            .catch(this.handleError);
    }

    getWinRate(heroId: number): Observable<WinRate> {
        return this._http.get(this.winRateUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(winrate => winrate.json() as WinRate)
            .catch(this.handleError);
    }

    getMostUsedItems(heroId: number): Observable<MostUsedItems[]> {
        return this._http.get(this.mostUsedItemsUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(mostUsedItems => mostUsedItems.json() as MostUsedItems[])
            .catch(this.handleError);
    }

    getMatchDetails(heroId: number): Observable<MatchDetails[]> {
        return this._http.get(this.matchDetailsUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(matchDetails => matchDetails.json() as MatchDetails[])
            .catch(this.handleError);
    }

    getPerMin(heroId: number): Observable<PerMin> {
        return this._http.get(this.perMinUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(perMin => perMin.json() as PerMin)
            .catch(this.handleError);
    }

    getLastHitsAndDenies(heroId: number): Observable<LastHitsDenies> {
        return this._http.get(this.lastHitsDeniesUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(lhdeny => lhdeny.json() as LastHitsDenies)
            .catch(this.handleError);
    }

    getBestVersus(heroId: number): Observable<BestVersus[]> {
        return this._http.get(this.bestVersusUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(bv => bv.json() as BestVersus[])
            .catch(this.handleError);
    }

    getWorstVersus(heroId: number): Observable<WorstVersus[]> {
        return this._http.get(this.worstVersusUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(wv => wv.json() as WorstVersus[])
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}