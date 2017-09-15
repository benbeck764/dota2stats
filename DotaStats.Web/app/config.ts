import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';


export interface ConfigObject
{
    environment: string;
    apiBaseUrl: string;
}

@Injectable()
export class Config {

    public config: ConfigObject;
    private env: Object;

    constructor(private http: Http) {
        
    }

    load(environment: any): Promise<any> {
        return new Promise((resolve, reject) => {

            this.http.get('/config/env.' + environment + '.json')
                .map(res => res.json())
                .catch((error: any) => {
                    console.error(error);
                    return Observable.throw(error.json().error || 'Server error');
                })
                .subscribe((data: ConfigObject) => {
                    this.config = data;
                    resolve(true);
                });

        });
    }

    get(key: any) {
        return this.config[key];
    }
}