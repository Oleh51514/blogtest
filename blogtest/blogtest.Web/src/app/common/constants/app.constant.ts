import { Injectable } from '@angular/core';


export const appConstant = {
    apiServer: 'http://localhost:5005/',
    authPath: 'api/Identity',
    confirmEmailUrl: 'http://localhost:5300/register/confirm-email',
    confirEmailByInviteUrl: 'http://localhost:5300/register/confirm-invite',
}
export const appLocalStorage = {
    authData: 'authData'
}

export const QueryParamsConfirmEmail = {
    userId: 'userid',
    token: 'token'
}

@Injectable()
export class Configuration {
    public Server = 'https://localhost:44390/';
    public FileServer = 'https://localhost:44378/';
}

