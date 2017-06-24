import { RouterModule } from '@angular/router';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser'
import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DialogModule } from 'primeng/primeng';

/* constant */ import { appConstant } from '../common/index.constants';
/* api-service */ import { CustomRequestOptions } from '../common/services/api/custom-request-options.service';
/* api-service */ import { TenantApiService } from '../common/services/api/entities/tenant.api.service';
/* api-service */ import { AccountApiService } from '../common/services/api/entities/account.api.service';


@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        ReactiveFormsModule,
        FormsModule,
        DialogModule
    ],
    declarations: [
    //    TemplateModalComponent
    ],
    exports: [
        // TemplateModalComponent,
        ReactiveFormsModule,
        FormsModule
    ],
    providers: [
        CustomRequestOptions,
        TenantApiService,
        AccountApiService
    ]
})
export class SharedModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: SharedModule,
            providers: [
                CustomRequestOptions,
                TenantApiService
            ]
        };
    }
}