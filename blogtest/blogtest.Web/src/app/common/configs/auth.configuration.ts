import { Injectable } from '@angular/core';

@Injectable()
export class AuthConfiguration {

    stsServer = 'http://localhost:5000';

    redirect_url = 'http://localhost:5300';

    // The Client MUST validate that the aud (audience) Claim contains its client_id value registered at the Issuer identified by the iss (issuer) Claim as an audience.
    // The ID Token MUST be rejected if the ID Token does not list the Client as a valid audience, or if it contains additional audiences not trusted by the Client.
    client_id = 'angularclient';

    response_type = 'id_token';

    scope = 'openid profile email';

    post_logout_redirect_uri = 'http://localhost:5300/Unauthorized';

    start_checksession = false;

    silent_renew = true;

    startup_route = '/home';

    // HTTP 403
    forbidden_route = '/Forbidden';

    // HTTP 401
    unauthorized_route = '/Unauthorized';

    log_console_warning_active = true;

    log_console_debug_active = true;

    // id_token C8: The iat Claim can be used to reject tokens that were issued too far away from the current time,
    // limiting the amount of time that nonces need to be stored to prevent attacks.The acceptable range is Client specific.
    max_id_token_iat_offset_allowed_in_seconds = 3;

    override_well_known_configuration = false;

    override_well_known_configuration_url = 'http://localhost:44386/wellknownconfiguration.json';

    // For some oidc, we require resource identifier to be provided along with the request.
    resource = '';
}