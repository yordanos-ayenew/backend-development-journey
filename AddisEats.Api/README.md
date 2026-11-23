## Day 58: Validation and Error Handling

### Request Validation

The API validates incoming requests using:

- **Route constraints:** Ensures route IDs are integers.
- **Data annotations:** Validates required fields, quantities, lengths, and amounts.
- **Custom validation:** Checks Ethiopian mobile numbers and ETB amounts.
- **Business validation:** Checks restaurant availability, menu ownership, and order limits.
- **Cross-field validation:** Scheduled orders must include a delivery date and time.

### Order Pricing

Order totals are calculated on the server using menu item prices and restaurant delivery fees.

Clients cannot submit their own subtotal, delivery fee, or total.

### Error Handling

The API uses `Result<T>` for expected business failures and global exception middleware for unexpected exceptions.

Error responses include a code and trace ID.

### Error Catalogue

| Error Code | HTTP Status | Meaning |
|---|---:|---|
| VALIDATION_FAILED | 400 | Invalid request data |
| INVALID_PRICE | 400 | Invalid menu item price |
| RESTAURANT_NOT_FOUND | 404 | Restaurant does not exist |
| MENU_ITEM_NOT_FOUND | 404 | Menu item does not exist |
| ORDER_NOT_FOUND | 404 | Order does not exist |
| RESTAURANT_CLOSED | 409 | Restaurant is unavailable |
| MAX_OPEN_ORDERS | 409 | Customer has reached the open-order limit |
| ORDER_STATUS_CONFLICT | 409 | Order status cannot be changed |
| MENU_ITEM_MISMATCH | 422 | Menu item does not belong to the selected restaurant |
| INTERNAL_SERVER_ERROR | 500 | Unexpected server error |

Only include codes that your application actually produces.

### Example Error Response

```json
{
  "title": "Restaurant not found.",
  "status": 404,
  "code": "RESTAURANT_NOT_FOUND",
  "traceId": "example-trace-id"
}
```

### Testing

Tested:
- Valid order creation
- Invalid Ethiopian phone number
- Invalid order quantity
- Scheduled order without delivery time
- Nonexistent restaurant
- Global exception handling
- Server-side order price calculation

### Exception Handling

Unexpected exceptions are logged with their trace IDs. The API returns a generic Problem Details response without exposing stack traces or internal exception messages.