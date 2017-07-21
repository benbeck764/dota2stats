export interface Hero {
    hero_id: number;
    name: string;
    localized_name: string;
}

export interface KDA {
    kills: number;
    deaths: number;
    assists: number;
}

export interface WinRate {
    wins: number;
    losses: number;
    rate: number;
}

export interface MostUsedItems {
    id: number;
    name: string;
    count: number;
}

export interface MatchDetails {
    results: string;
    mode: string;
    kda: string;
    duration: string;
    items: any[];
    abilities: any[];
}

export interface PerMin {
    gpm: number;
    xpm: number;
}

export interface LastHitsDenies {
    lh: number;
    deny: number;
}

export interface WorstVersus {
    id: number;
    name: string;
    localized_name: string;
    count: number;
}

export interface BestVersus {
    id: number;
    name: string;
    localized_name: string;
    count: number;
}