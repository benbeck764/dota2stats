"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const router_1 = require("@angular/router");
const dashboard_component_1 = require("./dashboard/dashboard.component");
const hero_details_component_1 = require("./hero-details/hero-details.component");
const heroes_component_1 = require("./heroes/heroes.component");
const appRoutes = [
    {
        path: '',
        component: dashboard_component_1.Dashboard
    },
    {
        path: 'heroes',
        component: heroes_component_1.HeroesComponent
    },
    {
        path: 'herodetails',
        component: hero_details_component_1.HeroDetailsComponent
    },
    {
        path: '**',
        component: dashboard_component_1.Dashboard
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map