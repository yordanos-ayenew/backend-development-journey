# Addis Eats API – Endpoint Design

**API Version:** v1  
**Base URL:** `https://api.addiseats.et/api/v1`

This document defines the REST API endpoints for the Addis Eats application. It covers restaurants, menus, orders, payments, and authentication.

## 1. Restaurants

| Method | Path | Purpose | Success Code | Failure Code |
|---|---|---|---|---|
| GET | `/api/v1/restaurants` | Retrieve all restaurants with optional area filtering and pagination. | 200 OK | 400 Bad Request |
| GET | `/api/v1/restaurants/{id}` | Retrieve a specific restaurant by its ID. | 200 OK | 404 Not Found |
| GET | `/api/v1/restaurants/{id}/menu` | Retrieve all menu items belonging to a specific restaurant. | 200 OK | 404 Not Found |
| POST | `/api/v1/restaurants` | Create a new restaurant. | 201 Created | 400 Bad Request |
| PATCH | `/api/v1/restaurants/{id}` | Update selected information about a restaurant. | 200 OK | 404 Not Found |

## 2. Menus

| Method | Path | Purpose | Success Code | Failure Code |
|---|---|---|---|---|
| GET | `/api/v1/menu-items` | Retrieve menu items with optional restaurant and category filters. | 200 OK | 400 Bad Request |
| GET | `/api/v1/menu-items/{id}` | Retrieve a specific menu item by its ID. | 200 OK | 404 Not Found |
| POST | `/api/v1/restaurants/{id}/menu-items` | Add a new menu item to a restaurant. | 201 Created | 404 Not Found |
| PATCH | `/api/v1/menu-items/{id}` | Update selected information about a menu item. | 200 OK | 404 Not Found |
| DELETE | `/api/v1/menu-items/{id}` | Remove a menu item from the menu. | 204 No Content | 404 Not Found |

## 3. Orders

| Method | Path | Purpose | Success Code | Failure Code |
|---|---|---|---|---|
| POST | `/api/v1/orders` | Create a new customer order. | 201 Created | 422 Unprocessable Content |
| GET | `/api/v1/orders` | Retrieve orders belonging to the authenticated customer. | 200 OK | 401 Unauthorized |
| GET | `/api/v1/orders/{id}` | Retrieve details of a specific order. | 200 OK | 404 Not Found |
| PATCH | `/api/v1/orders/{id}/status` | Update the status of an existing order. | 200 OK | 409 Conflict |
| DELETE | `/api/v1/orders/{id}` | Cancel an order that has not yet been completed. | 204 No Content | 409 Conflict |

## 4. Payments

| Method | Path | Purpose | Success Code | Failure Code |
|---|---|---|---|---|
| POST | `/api/v1/payments/telebirr` | Initiate a TeleBirr payment for an existing order. | 201 Created | 503 Service Unavailable |
| GET | `/api/v1/payments/{id}` | Retrieve the details and status of a payment. | 200 OK | 404 Not Found |

## 5. Authentication

| Method | Path | Purpose | Success Code | Failure Code |
|---|---|---|---|---|
| POST | `/api/v1/users` | Register a new customer account. | 201 Created | 409 Conflict |
| POST | `/api/v1/auth/sessions` | Authenticate a user and create a new session with an access token. | 201 Created | 401 Unauthorized |
| DELETE | `/api/v1/auth/sessions/current` | Log out the currently authenticated user and invalidate the session. | 204 No Content | 401 Unauthorized |

---

## API Design Rules

1. All endpoints use the `/api/v1` version prefix.
2. Resource names are nouns and collection names are plural.
3. HTTP methods describe the action being performed.
4. Resource identifiers are included in the URL path.
5. Filtering and pagination use query strings.
6. Successful resource creation returns `201 Created`.
7. Successful deletion without a response body returns `204 No Content`.
8. Client errors use appropriate 4xx status codes, while unexpected server errors use 5xx status codes.
9. Authentication and authorization are required for protected endpoints.
