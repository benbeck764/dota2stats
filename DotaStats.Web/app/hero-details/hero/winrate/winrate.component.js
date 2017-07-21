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
const hero_details_service_1 = require("../../hero-details.service");
const loading_indicator_1 = require("../../../loading-indicator/loading-indicator");
let WinRateComponent = class WinRateComponent extends loading_indicator_1.LoadingPage {
    constructor(_heroesService) {
        super(true);
        this._heroesService = _heroesService;
    }
    ngOnInit() {
        this.winRate = this.getWinRate(this.currentHero.hero_id);
    }
    ngOnChanges(changes) {
        this.currentHero = changes['currentHero'].currentValue;
        if (!changes['currentHero'].isFirstChange()) {
            this.standby();
            this.winRate = this.getWinRate(this.currentHero.hero_id);
        }
    }
    getWinRate(id) {
        this._heroesService.getWinRate(id)
            .subscribe(winRate => {
            this.winRate = winRate;
            this.ready();
        });
        return this.winRate;
    }
};
__decorate([
    core_1.Input(),
    __metadata("design:type", Object)
], WinRateComponent.prototype, "currentHero", void 0);
WinRateComponent = __decorate([
    core_1.Component({
        selector: 'winrate',
        templateUrl: 'app/hero-details/hero/winrate/winrate.template.html',
        styleUrls: ['app/hero-details/hero/winrate/winrate.css']
    }),
    __metadata("design:paramtypes", [hero_details_service_1.HeroesService])
], WinRateComponent);
exports.WinRateComponent = WinRateComponent;
//# sourceMappingURL=winrate.component.js.map