"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const bestversus_component_1 = require("./hero/bestversus/bestversus.component");
const worstversus_component_1 = require("./hero/worstversus/worstversus.component");
const lhdeny_component_1 = require("./hero/lhdeny/lhdeny.component");
const permin_component_1 = require("./hero/permin/permin.component");
const matches_component_1 = require("./hero/matches/matches.component");
const items_component_1 = require("./hero/items/items.component");
const winrate_component_1 = require("./hero/winrate/winrate.component");
const kda_component_1 = require("./hero/kda/kda.component");
const hero_component_1 = require("./hero/hero.component");
const heroes_component_1 = require("./heroes.component");
let HeroDetailsModule = class HeroDetailsModule {
};
HeroDetailsModule = __decorate([
    core_1.NgModule({
        declarations: [bestversus_component_1.BestVersusComponent, worstversus_component_1.WorstVersusComponent, lhdeny_component_1.LastHitsDeniesComponent, permin_component_1.PerMinComponent, matches_component_1.MatchesComponent, items_component_1.MostUsedItemsComponent, winrate_component_1.WinRateComponent, kda_component_1.KdaComponent, hero_component_1.HeroComponent, heroes_component_1.HeroDetailsComponent]
    })
], HeroDetailsModule);
exports.HeroDetailsModule = HeroDetailsModule;
//# sourceMappingURL=heroes.module.js.map