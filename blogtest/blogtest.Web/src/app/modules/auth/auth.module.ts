import { NgModule, ModuleWithProviders, Injectable } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Http, Response, Headers } from '@angular/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { OidcSecurityService } from '../../common/services/auth/oidc.security.service';
import { AuthConfiguration } from '../../common/configs/auth.configuration';
import { OidcSecurityValidation } from '../../common/services/auth/oidc.security.validation';
import { OidcSecurityCheckSession } from '../../common/services/auth/oidc.security.check-session';
import { OidcSecuritySilentRenew } from '../../common/services/auth/oidc.security.silent-renew';
import { OidcSecurityUserService } from '../../common/services/auth/oidc.security.user-service';
import { OidcSecurityCommon } from '../../common/services/auth/oidc.security.common';
import { AuthWellKnownEndpoints } from '../../common/services/auth/auth.well-known-endpoints';

@NgModule({
    imports: [
        CommonModule
    ]
})
export class AuthModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: AuthModule,
            providers: [
                OidcSecurityService,
                OidcSecurityValidation,
                OidcSecurityCheckSession,
                OidcSecuritySilentRenew,
                OidcSecurityUserService,
                OidcSecurityCommon,
                AuthConfiguration,
                AuthWellKnownEndpoints
            ]
        };
    }

    public static forChild(): ModuleWithProviders {
        return {
            ngModule: AuthModule,
            providers: [
                OidcSecurityService,
                OidcSecurityValidation,
                OidcSecurityCheckSession,
                OidcSecuritySilentRenew,
                OidcSecurityUserService,
                OidcSecurityCommon,
                AuthConfiguration,
                AuthWellKnownEndpoints
            ]
        };
    }
}