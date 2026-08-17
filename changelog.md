# Changelog

## [2.0.0] - 2026-08-17

### Added
- Comprehensive support for the new Quickfile REST API (v2) across all 45 endpoints.
- Unified `QuickfileClient` with typed REST methods (`RestSearchClientsAsync`, `RestCreateInvoiceAsync`, `RestGetAccountMeAsync`, etc.).
- Complete strongly-typed models for REST requests, responses, and query parameters in `Quickfile.Net.Models.Rest`.
- Support for `BearerToken` authentication and configurable `RestBaseUrl` in `QuickfileOptions`.
- Multi-part form-data support for Receipt Hub and Document Management uploads (`RestUploadReceiptAsync`, `RestUploadSalesDocumentAsync`, `RestUploadGeneralDocumentAsync`).
- Custom `QuickfileRestException` with status code and error details.
- Generic wrappers `RestPagedResponse<T>` and `RestArrayResponse<T>` for structured pagination and array responses.

## [1.9.0] - 2026-04-22

### Added
- Webhook support for consuming and validating Quickfile notifications.
- `QuickfileWebhookPayload` and related event models.
- `QuickfileWebhookValidator` for MD5 signature verification.
- `QuickfileWebhookParser` for easy integration in ASP.NET Core applications.
- `WebhookSecret` property in `QuickfileOptions`.

## [1.8.3] - 2026-04-12

### Changed
- Updated NuGet `PackageProjectUrl` to https://www.meartechnology.co.uk.

## [1.8.2] - 2026-04-12

### Added
- XML Documentation comments for all `QuickfileClient` methods to provide IntelliSense support.
- GitHub Actions workflow for automated NuGet publication on version tags.

...
