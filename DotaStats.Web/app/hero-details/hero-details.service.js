"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const http_1 = require("@angular/http");
require("rxjs/add/operator/map");
require("rxjs/add/operator/toPromise");
require("rxjs/add/operator/catch");
require("rxjs/add/operator/do");
let HeroesService = class HeroesService {
    constructor(_http) {
        this._http = _http;
        this.accountId = 111871881;
        this.heroesUrl = "http://localhost:58064/api/heroes/all";
        this.kdaUrl = "http://localhost:58064/api/statistics/kda";
        this.winRateUrl = "http://localhost:58064/api/statistics/winrate";
        this.mostUsedItemsUrl = "http://localhost:58064/api/statistics/mostused";
        this.matchDetailsUrl = "http://localhost:58064/api/statistics/matches";
        this.perMinUrl = "http://localhost:58064/api/statistics/permin";
        this.lastHitsDeniesUrl = "http://localhost:58064/api/statistics/lhdeny";
        this.bestVersusUrl = "http://localhost:58064/api/statistics/bestversus";
        this.worstVersusUrl = "http://localhost:58064/api/statistics/worstversus";
    }
    getHeroes() {
        return this._http.get(this.heroesUrl)
            .map(heroes => heroes.json())
            .catch(this.handleError);
    }
    getKDA(heroId) {
        return this._http.get(this.kdaUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(kda => kda.json())
            .catch(this.handleError);
    }
    getWinRate(heroId) {
        return this._http.get(this.winRateUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(winrate => winrate.json())
            .catch(this.handleError);
    }
    getMostUsedItems(heroId) {
        return this._http.get(this.mostUsedItemsUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(mostUsedItems => mostUsedItems.json())
            .catch(this.handleError);
    }
    getMatchDetails(heroId) {
        return this._http.get(this.matchDetailsUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(matchDetails => matchDetails.json())
            .catch(this.handleError);
    }
    getPerMin(heroId) {
        return this._http.get(this.perMinUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(perMin => perMin.json())
            .catch(this.handleError);
    }
    getLastHitsAndDenies(heroId) {
        return this._http.get(this.lastHitsDeniesUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(lhdeny => lhdeny.json())
            .catch(this.handleError);
    }
    getBestVersus(heroId) {
        return this._http.get(this.bestVersusUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(bv => bv.json())
            .catch(this.handleError);
    }
    getWorstVersus(heroId) {
        return this._http.get(this.worstVersusUrl + "?accountId=" + this.accountId + "&heroId=" + heroId)
            .map(wv => wv.json())
            .catch(this.handleError);
    }
    handleError(error) {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
};
HeroesService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], HeroesService);
exports.HeroesService = HeroesService;
//# sourceMappingURL=hero-details.service.js.map