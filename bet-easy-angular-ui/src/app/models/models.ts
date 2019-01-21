export class BetEasyResponse {
    result: BetEasyItem[];
}

export class BetEasyItem {
    EventID: number;
    EventTypeDesc: string;
    EventName: string;
    AdvertisedStartTime: Date;    
    Venue: Venue;
}

export class Venue {
    Venue: string;
}

export enum EventType {
    Thoroughbred = 1,
    Trots = 2
}