import { Injectable } from '@angular/core'
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

import { BetEasyResponse } from '../models/models'

@Injectable()
export class BetEasyService {
    constructor(private client: HttpClient) {

    }

    get(): Observable<HttpResponse<BetEasyResponse>> {
        let url = "https://s3-ap-southeast-2.amazonaws.com/bet-easy-code-challenge/next-to-jump";

        var response = this.client.get<BetEasyResponse>(url, { observe: 'response' });

        return response;
    }
}


