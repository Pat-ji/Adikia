import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { IApiResponse } from "../models/api-response";
import { IGame } from "../models/game";
import { IPagination } from "../models/pagination";
import { PaginationParams } from "../models/pagination-params";

@Injectable({
    providedIn: 'root'
})
export class GameService {
    baseUrl = `${environment.apiUrl}game`;

    constructor(private http: HttpClient) {
    }

    getGames(pagination: PaginationParams) {
        let params = new HttpParams();
        params = params.append('pageIndex', pagination.pageNumber.toString());
        params = params.append('pageSize', pagination.pageSize.toString());

        return this.http.get<IApiResponse<IPagination<IGame>>>(`${this.baseUrl}/overview`, { observe: 'response', params })
            .pipe(map(response => response.body.data));
    }

    getUserGames(pagination: PaginationParams) {
        let params = new HttpParams();
        params = params.append('pageIndex', pagination.pageNumber.toString());
        params = params.append('pageSize', pagination.pageSize.toString());

        return this.http.get<IApiResponse<IPagination<IGame>>>(`${this.baseUrl}/user`, { observe: 'response', params })
            .pipe(map(response => response.body.data));
    }
}