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
const loading_indicator_1 = require("../../../loading-indicator/loading-indicator");
const hero_details_service_1 = require("../../hero-details.service");
let MatchesComponent = class MatchesComponent extends loading_indicator_1.LoadingPage {
    constructor(_heroesService) {
        super(true);
        this._heroesService = _heroesService;
    }
    ngOnInit() {
        this.details = this.getMatchDetails(this.currentHero.hero_id);
    }
    ngOnChanges(changes) {
        this.currentHero = changes['currentHero'].currentValue;
        if (!changes['currentHero'].isFirstChange()) {
            this.standby();
            this.details = this.getMatchDetails(this.currentHero.hero_id);
        }
    }
    getMatchDetails(id) {
        this._heroesService.getMatchDetails(id)
            .subscribe(details => {
            this.details = details;
            this.ready();
        });
        return this.details;
    }
};
__decorate([
    core_1.Input(),
    __metadata("design:type", Object)
], MatchesComponent.prototype, "currentHero", void 0);
MatchesComponent = __decorate([
    core_1.Component({
        selector: 'matchdetails',
        templateUrl: 'app/hero-details/hero/matches/matches.template.html',
        styleUrls: ['app/hero-details/hero/matches/matches.css']
    }),
    __metadata("design:paramtypes", [hero_details_service_1.HeroesService])
], MatchesComponent);
exports.MatchesComponent = MatchesComponent;
//# sourceMappingURL=matches.component.js.map