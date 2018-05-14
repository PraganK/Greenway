import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { TeamService } from '../../Services/teamservice.service'

@Component({
    selector: 'team',
    templateUrl: './team.component.html',
    providers: [TeamService]

})
export class TeamComponent {
    public teams: GreenwayTeam[];

    constructor(private _teamService: TeamService) {
        this.getTeams();
    }

    getTeams() {
        console.log("team component");
        this._teamService.getTeams().subscribe(
            data => this.teams = data)

    }

    //constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
    //    http.get(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
    //        this.teams = result.json() as GreenwayTeam[];
    //    }, error => console.error(error));
    //}
}

interface GreenwayTeam {
    id: number;
    name: string;
    category: string;
}
