import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {BestVersusComponent} from "./hero/bestversus/bestversus.component";
import {WorstVersusComponent} from "./hero/worstversus/worstversus.component";
import {LastHitsDeniesComponent} from "./hero/lhdeny/lhdeny.component";
import {PerMinComponent} from "./hero/permin/permin.component";
import {MatchesComponent} from "./hero/matches/matches.component";
import {MostUsedItemsComponent} from "./hero/items/items.component";
import {WinRateComponent} from "./hero/winrate/winrate.component";
import {KdaComponent} from "./hero/kda/kda.component";
import {HeroComponent} from "./hero/hero.component";
import { HeroDetailsComponent } from "./hero-details.component";
import {LoadingIndicatorComponent} from "../loading-indicator/loading-indicator";

@NgModule({
    imports: [CommonModule],
    declarations: [HeroDetailsComponent, HeroComponent, LoadingIndicatorComponent, BestVersusComponent, WorstVersusComponent, LastHitsDeniesComponent, PerMinComponent, MatchesComponent, MostUsedItemsComponent, WinRateComponent, KdaComponent],
    exports: [HeroDetailsComponent, HeroComponent, LoadingIndicatorComponent, BestVersusComponent, WorstVersusComponent, LastHitsDeniesComponent, PerMinComponent, MatchesComponent, MostUsedItemsComponent, WinRateComponent, KdaComponent]
})

export class HeroDetailsModule { }