using System.Text.Json.Serialization;

namespace SOHome.Domain.Responses
{
    public class MtlsEndpointAliases
    {
        [JsonPropertyName("token_endpoint")]
        public string TokenEndpoint { get; set; }

        [JsonPropertyName("revocation_endpoint")]
        public string RevocationEndpoint { get; set; }

        [JsonPropertyName("introspection_endpoint")]
        public string IntrospectionEndpoint { get; set; }

        [JsonPropertyName("device_authorization_endpoint")]
        public string DeviceAuthorizationEndpoint { get; set; }

        [JsonPropertyName("registration_endpoint")]
        public string RegistrationEndpoint { get; set; }

        [JsonPropertyName("userinfo_endpoint")]
        public string UserinfoEndpoint { get; set; }

        [JsonPropertyName("pushed_authorization_request_endpoint")]
        public string PushedAuthorizationRequestEndpoint { get; set; }

        [JsonPropertyName("backchannel_authentication_endpoint")]
        public string BackchannelAuthenticationEndpoint { get; set; }
    }
    public class OAuthUrls
    {
        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("authorization_endpoint")]
        public string AuthorizationEndpoint { get; set; }

        [JsonPropertyName("token_endpoint")]
        public string TokenEndpoint { get; set; }

        [JsonPropertyName("introspection_endpoint")]
        public string IntrospectionEndpoint { get; set; }

        [JsonPropertyName("userinfo_endpoint")]
        public string UserinfoEndpoint { get; set; }

        [JsonPropertyName("end_session_endpoint")]
        public string EndSessionEndpoint { get; set; }

        [JsonPropertyName("frontchannel_logout_session_supported")]
        public bool FrontchannelLogoutSessionSupported { get; set; }

        [JsonPropertyName("frontchannel_logout_supported")]
        public bool FrontchannelLogoutSupported { get; set; }

        [JsonPropertyName("jwks_uri")]
        public string JwksUri { get; set; }

        [JsonPropertyName("check_session_iframe")]
        public string CheckSessionIframe { get; set; }

        [JsonPropertyName("grant_types_supported")]
        public List<string> GrantTypesSupported { get; } = new List<string>();

        [JsonPropertyName("acr_values_supported")]
        public List<string> AcrValuesSupported { get; } = new List<string>();

        [JsonPropertyName("response_types_supported")]
        public List<string> ResponseTypesSupported { get; } = new List<string>();

        [JsonPropertyName("subject_types_supported")]
        public List<string> SubjectTypesSupported { get; } = new List<string>();

        [JsonPropertyName("id_token_signing_alg_values_supported")]
        public List<string> IdTokenSigningAlgValuesSupported { get; } = new List<string>();

        [JsonPropertyName("id_token_encryption_alg_values_supported")]
        public List<string> IdTokenEncryptionAlgValuesSupported { get; } = new List<string>();

        [JsonPropertyName("id_token_encryption_enc_values_supported")]
        public List<string> IdTokenEncryptionEncValuesSupported { get; } = new List<string>();

        [JsonPropertyName("userinfo_signing_alg_values_supported")]
        public List<string> UserinfoSigningAlgValuesSupported { get; } = new List<string>();

        [JsonPropertyName("userinfo_encryption_alg_values_supported")]
        public List<string> UserinfoEncryptionAlgValuesSupported { get; } = new List<string>();

        [JsonPropertyName("userinfo_encryption_enc_values_supported")]
        public List<string> UserinfoEncryptionEncValuesSupported { get; } = new List<string>();

        [JsonPropertyName("request_object_signing_alg_values_supported")]
        public List<string> RequestObjectSigningAlgValuesSupported { get; } = new List<string>();

        [JsonPropertyName("request_object_encryption_alg_values_supported")]
        public List<string> RequestObjectEncryptionAlgValuesSupported { get; } = new List<string>();

        [JsonPropertyName("request_object_encryption_enc_values_supported")]
        public List<string> RequestObjectEncryptionEncValuesSupported { get; } = new List<string>();

        [JsonPropertyName("response_modes_supported")]
        public List<string> ResponseModesSupported { get; } = new List<string>();

        [JsonPropertyName("registration_endpoint")]
        public string RegistrationEndpoint { get; set; }

        [JsonPropertyName("token_endpoint_auth_methods_supported")]
        public List<string> TokenEndpointAuthMethodsSupported { get; } = new List<string>();

        [JsonPropertyName("token_endpoint_auth_signing_alg_values_supported")]
        public List<string> TokenEndpointAuthSigningAlgValuesSupported { get; } = new List<string>();

        [JsonPropertyName("introspection_endpoint_auth_methods_supported")]
        public List<string> IntrospectionEndpointAuthMethodsSupported { get; } = new List<string>();

        [JsonPropertyName("introspection_endpoint_auth_signing_alg_values_supported")]
        public List<string> IntrospectionEndpointAuthSigningAlgValuesSupported { get; } = new List<string>();

        [JsonPropertyName("authorization_signing_alg_values_supported")]
        public List<string> AuthorizationSigningAlgValuesSupported { get; } = new List<string>();

        [JsonPropertyName("authorization_encryption_alg_values_supported")]
        public List<string> AuthorizationEncryptionAlgValuesSupported { get; } = new List<string>();

        [JsonPropertyName("authorization_encryption_enc_values_supported")]
        public List<string> AuthorizationEncryptionEncValuesSupported { get; } = new List<string>();

        [JsonPropertyName("claims_supported")]
        public List<string> ClaimsSupported { get; } = new List<string>();

        [JsonPropertyName("claim_types_supported")]
        public List<string> ClaimTypesSupported { get; } = new List<string>();

        [JsonPropertyName("claims_parameter_supported")]
        public bool ClaimsParameterSupported { get; set; }

        [JsonPropertyName("scopes_supported")]
        public List<string> ScopesSupported { get; } = new List<string>();

        [JsonPropertyName("request_parameter_supported")]
        public bool RequestParameterSupported { get; set; }

        [JsonPropertyName("request_uri_parameter_supported")]
        public bool RequestUriParameterSupported { get; set; }

        [JsonPropertyName("require_request_uri_registration")]
        public bool RequireRequestUriRegistration { get; set; }

        [JsonPropertyName("code_challenge_methods_supported")]
        public List<string> CodeChallengeMethodsSupported { get; } = new List<string>();

        [JsonPropertyName("tls_client_certificate_bound_access_tokens")]
        public bool TlsClientCertificateBoundAccessTokens { get; set; }

        [JsonPropertyName("revocation_endpoint")]
        public string RevocationEndpoint { get; set; }

        [JsonPropertyName("revocation_endpoint_auth_methods_supported")]
        public List<string> RevocationEndpointAuthMethodsSupported { get; } = new List<string>();

        [JsonPropertyName("revocation_endpoint_auth_signing_alg_values_supported")]
        public List<string> RevocationEndpointAuthSigningAlgValuesSupported { get; } = new List<string>();

        [JsonPropertyName("backchannel_logout_supported")]
        public bool BackchannelLogoutSupported { get; set; }

        [JsonPropertyName("backchannel_logout_session_supported")]
        public bool BackchannelLogoutSessionSupported { get; set; }

        [JsonPropertyName("device_authorization_endpoint")]
        public string DeviceAuthorizationEndpoint { get; set; }

        [JsonPropertyName("backchannel_token_delivery_modes_supported")]
        public List<string> BackchannelTokenDeliveryModesSupported { get; } = new List<string>();

        [JsonPropertyName("backchannel_authentication_endpoint")]
        public string BackchannelAuthenticationEndpoint { get; set; }

        [JsonPropertyName("backchannel_authentication_request_signing_alg_values_supported")]
        public List<string> BackchannelAuthenticationRequestSigningAlgValuesSupported { get; } = new List<string>();

        [JsonPropertyName("require_pushed_authorization_requests")]
        public bool RequirePushedAuthorizationRequests { get; set; }

        [JsonPropertyName("pushed_authorization_request_endpoint")]
        public string PushedAuthorizationRequestEndpoint { get; set; }

        [JsonPropertyName("mtls_endpoint_aliases")]
        public MtlsEndpointAliases MtlsEndpointAliases { get; set; }
    }
}
