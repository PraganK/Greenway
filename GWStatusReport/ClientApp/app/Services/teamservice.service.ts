﻿import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Console } from '@angular/core/src/console';


@Injectable()

export class TeamService {

    myAppUrl: string = "";
    
    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getTeams() {

        console.log("team service");
        return this._http.get(this.myAppUrl + 'api/Team')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);

    }

    getTeamById(id: number) {

        return this._http.get(this.myAppUrl + "api/Team/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);

    }

    errorHandler(error: Response) {

        console.log(error);
        return Observable.throw(error);

    }
}