import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { IApiResponse } from "../models/api-response";
import { IPagination } from "../models/pagination";
import { PaginationParams } from "../models/pagination-params";
import { ISession } from "../models/session";

@Injectable({
    providedIn: 'root'
})
export class SessionService {
    baseUrl = `${environment.apiUrl}session`;

    constructor(private http: HttpClient) {
    }

    getSessions(pagination: PaginationParams) {
        let params = new HttpParams();
        params = params.append('pageIndex', pagination.pageNumber.toString());
        params = params.append('pageSize', pagination.pageSize.toString());

        return this.http.get<IApiResponse<IPagination<ISession>>>(`${this.baseUrl}/overview`, { observe: 'response', params })
            .pipe(map(response => response.body.data));
    }

    createSession(gameId: number) {
        return this.http.post<IApiResponse<ISession>>(`${this.baseUrl}/create?gameId=${gameId}`, { observe: 'response' })
            .pipe(map(response => response.data));
    }
}