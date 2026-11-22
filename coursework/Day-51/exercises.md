Day 51 – Reading Sheet Exercises

Exercise 1 – What is a server?

A server is a program that waits for requests from other programs or users and responds to them. It works like a waiter in a restaurant: a customer makes an order, the waiter takes the request to the kitchen, and the kitchen prepares and delivers the food. Similarly, a server receives requests, processes them, and sends back the requested information or results. For example, when someone opens Addis Eats and requests a list of restaurants, the server retrieves the restaurant information and sends it back to the user.

Exercise 2 – Inspect three network requests

I opened Google Chrome and visited https://www.google.com. Using Developer Tools (F12), I inspected three Fetch/XHR requests in the Network tab.

| Request | HTTP Method | Full Path | Status Code | Request Body |
|---|---|---|---|---|
| GetAsyncData | POST | /$rpc/google.internal.onegoogle.asyncdata.v1.AsyncDataService/GetAsyncData | 200 OK | Yes |
| Create | POST | /$rpc/google.internal.waa.v1.Waa/Create | 200 OK | Yes |
| Ping | POST | /$rpc/google.internal.waa.v1.Waa/Ping | 200 OK | Yes |

**Observation:**

All three requests use the POST method and returned a 200 OK response, meaning they were successfully processed. Each request carried a body, as indicated by the Content-Length header and the Payload section in Developer Tools.

Exercise 3 – Inspect request and response headers

### Request Headers

| Header | Value | Purpose |
|---|---|---|
| Accept | */* | Indicates that the client accepts any response format. |
| Accept-Language | en-GB,en-US;q=0.9,en;q=0.8 | Indicates the preferred languages for the response. |
| Content-Type | application/json+protobuf | Specifies the format of the request body. |
| Origin | https://www.google.com | Identifies the website that initiated the request. |

### Response Headers

| Header | Value | Purpose |
|---|---|---|
| Content-Type | application/json+protobuf; charset=UTF-8 | Specifies the format of the response body. |
| Content-Encoding | gzip | Indicates that the response body is compressed using gzip. |
| Cache-Control | private | Specifies that the response is intended for a private cache. |
| Server | ESF | Identifies the server software handling the request. |

**Conclusion:**

Request headers provide information about the request sent by the client, while response headers provide information about the response returned by the server.

Exercise 4 – Write a full HTTP request

Scenario: Create an order for two portions of menu item 7 at restaurant 14 in Bole, paid by TeleBirr.

```http
POST /api/v1/orders HTTP/1.1
Host: api.addiseats.et
Content-Type: application/json
Accept: application/json
Authorization: Bearer <access_token>

{
    "restaurantId": 14,
    "area": "Bole",
    "items": [
        {
            "menuItemId": 7,
            "qty": 2
        }
    ],
    "paymentMethod": "TeleBirr"
}
```

Exercise 5 – Choose the correct status codes

| Scenario | Status Code | Justification |
|---|---|---|
| (a) A list of restaurants is returned. | **200 OK** | The request was successful and the restaurant list was returned. |
| (b) An order is created. | **201 Created** | A new order resource was successfully created. |
| (c) An order is cancelled and nothing is returned. | **204 No Content** | The cancellation succeeded, but there is no response body. |
| (d) The qty field arrives as "two". | **400 Bad Request** | The quantity has an invalid data type and the request body is malformed. |
| (e) The authentication token has expired. | **401 Unauthorized** | The client's authentication credentials are no longer valid. |
| (f) A courier attempts to edit a menu. | **403 Forbidden** | The courier is authenticated but does not have permission to edit menus. |
| (g) Someone requests order 99999, which does not exist. | **404 Not Found** | The requested order resource cannot be found. |
| (h) Your code throws an unhandled exception. | **500 Internal Server Error** | An unexpected server-side error occurred while processing the request. |

Exercise 6 – Find a public API and describe its contract

### API Selected: JSONPlaceholder

JSONPlaceholder is a free fake REST API used for testing and learning HTTP requests.

**Three things its API contract promises:**

1. It provides resources such as posts, comments, users, albums, photos, and todos through defined REST endpoints.

2. It supports standard HTTP methods, including GET, POST, PUT, PATCH, and DELETE.

3. It returns data in JSON format, making it easy for applications to consume and process the responses.

**One thing I would want to know before depending on it:**

I would want to know its availability guarantees and rate limits, including how many requests I can make within a specific period and whether the service guarantees uptime.