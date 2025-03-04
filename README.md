
# PHI Redactor
A simple application to process and redact PHI from lab orders.

## Setup
### Backend
1. Install .NET 8.
2. Run `dotnet run`.

### Frontend
1. Install Node.js.
2. Run `npm start`.

## Approach
- Used **regex** to identify PHI.
- Replaced sensitive data with `[REDACTED]`.
- Simple React UI for file upload.

## Future Improvements
- Add database support.
- Improve regex patterns.
- Add user authentication.
