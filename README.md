# Flight Search API - Code Case Documentation

This project is designed with three microservices to simulate a flight search functionality:

- **FlightSearch.API**: The main entry point for the flight search functionality.
- **Provider Services** (HopeAir & AybJet): Mock APIs representing flight providers.
- **MockGenerator**: Used to generate mock data for the providers.

The project follows **Clean Architecture** principles, but for simplicity, a full implementation of Clean Architecture has not been carried out.

## Project Structure

### Application Layer
The core services are placed under the **Application** layer to provide abstraction for unit tests.

### Mock Data Generation
Mock data is generated using the **Bogus** library, which simulates responses from the provider APIs.

### HTTP Client Service
A generic **HttpClient** service is created for making requests to provider APIs. Configurations, including base URLs and timeouts, are managed through the `appsettings.json` file.
Timeout Management: The default timeout for provider API requests is set to TimeSpan.FromMilliseconds(30000).

#### Example Configuration

```json
"HttpClients": {
  "Providers": {
    "AybJet": {
      "BaseUrl": "http://localhost:8082/api"
    },
    "HopeAir": {
      "BaseUrl": "http://localhost:8081/api"
    }
  }
}
```

### Unit Tests
Unit test projects utilize the xUnit framework and the Moq library for mocking dependencies during tests.

## Future Improvements and Considerations

### Clean Architecture
For future scalability, **Clean Architecture** can be fully implemented. This will provide a clearer separation between layers, such as **Domain**, **Application**, **Infrastructure**, etc., improving maintainability and enabling easier system updates without affecting other layers.

### Asynchronous Data Flow
For large datasets returned by providers, an **asynchronous data flow** can be implemented to improve the user experience. The **Producer-Consumer** design pattern can be used:

- **Producer**: Initiates the data flow by querying providers asynchronously.
- **Consumer**: Processes and combines the retrieved data asynchronously for a quicker response to the user.

### Logging Structure
To ensure better observability and troubleshooting, a centralized and consistent logging structure can be implemented:

- **Centralized Logging**: Use a logging framework such as Serilog, NLog, or Microsoft.Extensions.Logging to ensure all logs are directed to a centralized location (e.g., Elasticsearch, Application Insights, or a file-based system).

### Error Handling Structure
Robust error management ensures the application can handle unexpected scenarios gracefully while providing meaningful feedback to users and logs for developers:

By implementing a structured logging and error handling mechanism, the system can become more reliable, maintainable, and easier to troubleshoot in production environments.

## Building and Running the Services

To start the services, follow these steps:

### Build the images and start the containers
Open your terminal and navigate to the root of the project where the `docker-compose.override.yml` file is located. Run the following command:

```bash
docker-compose up --build
```
This will build the images for all the services defined in the docker-compose.yml file and start the containers.

### Access the Services

Once the containers are running, you can access the services locally via the following URLs:

- **Flight Search API**: [http://localhost:8080](http://localhost:8080)
- **HopeAir Provider**: [http://localhost:8081](http://localhost:8081)
- **AybJet Provider**: [http://localhost:8082](http://localhost:8082)

### Stopping the Containers
```bash
docker-compose down
```
This will stop and remove the containers but retain the images, allowing you to restart the services later without needing to rebuild them.