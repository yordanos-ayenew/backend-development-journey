# AddisEats API

A RESTful Web API built with C# and ASP.NET Core for managing restaurants, menu items, and food orders.

## Technologies
- C#
- .NET 8
- ASP.NET Core Web API
- Swagger

## Getting Started

Clone the repository:

```bash
git clone YOUR_REPOSITORY_URL
```

Navigate to the project folder:

```bash
cd AddisEats.Api
```

Run the application:

```bash
dotnet run
```

Open the Swagger URL shown in the terminal to test the API.

## API Endpoints

### Menu Items

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/v1/menu-items` | Get all menu items |
| GET | `/api/v1/menu-items/{id:int}` | Get a menu item |
| POST | `/api/v1/menu-items` | Create a menu item |

### Restaurants

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/v1/restaurants` | Get all restaurants |
| GET | `/api/v1/restaurants/{id:int}` | Get a restaurant |
| GET | `/api/v1/restaurants/{id:int}/menu` | Get a restaurant's menu |

### Orders

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/v1/orders/{id:int}` | Get an order |
| POST | `/api/v1/orders` | Create an order |
| PATCH | `/api/v1/orders/{id:int}/status` | Update order status |

## Query Parameters

The restaurants endpoint supports:

| Parameter | Default | Description |
|---|---|---|
| `area` | None | Filter by area |
| `areas` | Empty | Filter by multiple areas |
| `maxFeeEtb` | None | Filter by delivery fee |
| `page` | 1 | Page number |
| `limit` | 20 | Results per page |

Example:

```http
GET /api/v1/restaurants?area=Bole&page=1&limit=10
```

Pagination rules:
- Default limit: 20
- Maximum limit: 100
- Page and limit must be greater than zero.
- Limits above 100 are capped at 100.
- Unknown query parameters are ignored.

## Response Formats

### Successful Collection Response

```json
{
  "data": [],
  "page": 1,
  "pageSize": 20,
  "total": 12
}
```

### Error Response

```json
{
  "code": "RESTAURANT_NOT_FOUND",
  "message": "Restaurant not found."
}
```

## Error Catalogue

| Error Code | HTTP Status | Description |
|---|---:|---|
| `VALIDATION_ERROR` | 400 | Invalid request data |
| `INVALID_PAGINATION` | 400 | Invalid page or limit |
| `INVALID_PRICE` | 400 | Invalid menu item price |
| `RESTAURANT_NOT_FOUND` | 404 | Restaurant not found |
| `MENU_ITEM_NOT_FOUND` | 404 | Menu item not found |
| `ORDER_NOT_FOUND` | 404 | Order not found |
| `DUPLICATE_RESOURCE` | 409 | Resource already exists |
| `INVALID_ORDER_STATUS` | 400 | Invalid order status |
| `INTERNAL_SERVER_ERROR` | 500 | Unexpected server error |

## Testing

The API can be tested using:
- Swagger UI
- VS Code `.http` files
- Postman

## Notes

- Data is currently stored in memory.
- Data resets when the application restarts.
- API routes use RESTful naming conventions.
- DTOs are used to control returned data.
- JSON responses use camelCase.
- Null values are omitted.
- Enum values are returned as strings.

## Author

Developed as part of the CodeOps Full Stack Software Development Program.

**Project:** AddisEats API  
**Track:** .NET (C#) Backend Development