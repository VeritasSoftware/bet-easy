import { Injectable, Inject } from '@angular/core'
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

import { BetEasyResponse } from '../models/models'
import { APP_CONFIG, AppConfig } from '../app-config.module';

@Injectable()
export class BetEasyService {
    constructor(private client: HttpClient, @Inject(APP_CONFIG) private config: AppConfig) {

    }

    get(): Observable<HttpResponse<BetEasyResponse>> {
        let url = this.config.apiEndpoint;

        var response = this.client.get<BetEasyResponse>(url, { observe: 'response' });

        return response;
    }
}


