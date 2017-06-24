import { Injectable } from '@angular/core';
import { RequestOptions, Headers } from '@angular/http';
import { NgRedux, select } from '@angular-redux/store';

@Injectable()
export class CustomRequestOptions {

  public optionRequest: RequestOptions;
  public optionRequestAuth: RequestOptions;
  // private accessToken$: Observable<any>;

  constructor(    
  ) {
    this.setOptionRequest();
    this.setOptionRequestAuth();
  }

  private setOptionRequest() {
    let headers: Headers = new Headers();
    headers.append('Content-Type', 'application/json');
    this.optionRequest = new RequestOptions({headers: headers});
  }

  private setOptionRequestAuth() {
    let headers: Headers = new Headers();
    headers.append('Content-Type', 'application/json');
    this.optionRequestAuth = new RequestOptions({headers: headers});

    // let headers: Headers = new Headers();
    // headers.append('Content-Type', 'application/json');
    // headers.append('Authorization', 'Bearer ' + accessToken);
    // this.optionRequestAuth = new RequestOptions({headers: headers});
  }
}