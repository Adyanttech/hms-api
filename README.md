# Hospital Management System API

This is a .NET Core Web API for managing hospital operations such as appointments, patients, doctors, and tokens.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Postman](https://www.postman.com/) or any API testing tool (optional)

## Steps to Run the API

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd hms-api
   ```

2. **Set Up the Database**

Update the connection string in HospitalManagementSystem.API/appsettings.json:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=<YourServerName>;Database=HMS;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

3. **Restore Dependencies**
dotnet restore

4. **Build the Solution**
dotnet build

5. **Run the API**
dotnet run --project HospitalManagementSystem.API/HospitalManagementSystem.API.csproj

6. **Access the API**
Open your browser or API testing tool and navigate to:
Swagger UI: http://localhost:5056/swagger/index.html
API Base URL: http://localhost:5056

## Available Endpoints

### Appointments
- `GET /api/Appointment` - Get today's appointments.
- `GET /api/Appointment/{id}` - Get appointment by ID.
- `POST /api/Appointment` - Add a new appointment.

### Patients
- `GET /api/Patient` - Get all patients.
- `GET /api/Patient/{id}` - Get patient by ID.
- `POST /api/Patient/RegisterPatient` - Register a new patient.
- `PUT /api/Patient/{id}` - Update patient details.

### Tokens
- `GET /api/Token/LiveStatus` - Get live token status.

## Notes
- Ensure the database is running and accessible before starting the API.
- Use the Swagger UI for testing and exploring the API endpoints.
- Update the Twilio credentials in `appsettings.json` if using OTP services.

## Troubleshooting
- If you encounter issues with the database connection, verify the connection string and SQL Server instance.
- For SSL-related issues, ensure the `TrustServerCertificate` option is set to `True` in the connection string.