export interface Hero {
    hero_id: number;
    name: string;
    localized_name: string;
}


export interface HeroRecord {
    hero: Hero;
    totalGames: number;
    wins: number;
    losses: number;
    winRate: number;
    bestWinStreak: number;
    currentWinStreak: number;
    averageKills: number;
    averageDeaths: number;
    averageAssists: number;
    averageGpm: number;
    averageXpm: number;
    bestKills: number;
    bestAssists: number;
    bestGpm: number;
    BestXpPerMinute: number;
}
