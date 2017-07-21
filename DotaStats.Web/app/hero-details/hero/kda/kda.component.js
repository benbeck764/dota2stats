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
let KdaComponent = class KdaComponent extends loading_indicator_1.LoadingPage {
    constructor(_heroesService) {
        super(true);
        this._heroesService = _heroesService;
    }
    ngOnInit() {
        this.getKDA(this.currentHero.hero_id);
    }
    ngOnChanges(changes) {
        this.currentHero = changes['currentHero'].currentValue;
        if (!changes['currentHero'].isFirstChange()) {
            this.standby();
            this.getKDA(this.currentHero.hero_id);
        }
    }
    getKDA(heroId) {
        this._heroesService.getKDA(heroId)
            .subscribe(kda => {
            this.kda = kda;
            this.ready();
        });
    }
};
__decorate([
    core_1.Input(),
    __metadata("design:type", Object)
], KdaComponent.prototype, "currentHero", void 0);
KdaComponent = __decorate([
    core_1.Component({
        selector: 'kda',
        templateUrl: 'app/hero-details/hero/kda/kda.template.html',
        styleUrls: ['app/hero-details/hero/kda/kda.css']
    }),
    __metadata("design:paramtypes", [hero_details_service_1.HeroesService])
], KdaComponent);
exports.KdaComponent = KdaComponent;
//# sourceMappingURL=kda.component.js.map