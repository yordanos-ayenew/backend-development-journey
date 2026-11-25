# Day 59: Middleware

## Overview
Implemented custom middleware and an action filter in the Addis Eats API to handle cross-cutting concerns such as request tracking, timing, and API key protection.

## Features

### 1. Correlation ID Middleware
- Reads the `X-Correlation-Id` request header.
- Generates a new ID if one is not provided.
- Sets the ID as the request TraceIdentifier.
- Returns the ID in the response header.
- Adds the ID to downstream logging scopes.

### 2. Request Timing Middleware
- Measures request execution time.
- Logs HTTP method, path, response status, and duration.
- Uses Warning level for requests taking more than 1000 ms.

### 3. API Key Middleware
- Checks the `X-API-Key` request header.
- Returns 401 Unauthorized when the key is missing or invalid.
- Protects the `/admin` branch using `app.Map()`.

Demo API key: `AddisEatsAdminDemoKey`

### 4. Audit Action Filter
- Logs the controller action being executed.
- Records the action arguments.
- Logs the action result status code.

Applied to `OrdersController`.

## Middleware Pipeline

The pipeline follows this order:

| Order | Component | Purpose |
|---|---|---|
| 1 | Exception handling | Handles unexpected exceptions |
| 2 | Correlation ID | Tracks requests |
| 3 | Request timing | Measures request duration |
| 4 | Swagger | API documentation in development |
| 5 | HTTPS redirection | Redirects HTTP requests |
| 6 | CORS | Allows frontend requests |
| 7 | Routing | Matches endpoints |
| 8 | Rate limiting | Reserved for Day 63 |
| 9 | Authentication | Reserved for Day 61 |
| 10 | Authorization | Reserved for Day 62 |
| 11 | Controllers | Executes API endpoints |

Rate limiting, authentication, and authorization are currently commented out.

## Testing

Tested or intended test cases:

- Request with an existing correlation ID.
- Request without a correlation ID.
- Request timing logs.
- `/admin` without an API key returns 401.
- `/admin` with a valid API key returns `Admin branch reached.`
- Order endpoint logs action names and arguments.

## Important Notes

- No scoped services are injected into middleware constructors.
- Middleware runs in the registered order.
- The API key is for demonstration purposes only and should not be used as a production security solution.

## Technologies
- C#
- ASP.NET Core Web API
- Custom Middleware
- MVC Action Filters
- Dependency Injection
- Logging