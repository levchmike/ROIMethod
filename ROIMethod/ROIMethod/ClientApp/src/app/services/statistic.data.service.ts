import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class StatisticDataService {

  private url = "/api/statisticbq";

  constructor(private http: HttpClient) {
  }

  getStatistics() {
    
    return this.http.get(this.url);
  }

}
