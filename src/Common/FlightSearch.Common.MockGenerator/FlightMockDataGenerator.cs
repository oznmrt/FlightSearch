﻿using Bogus;
using FlightSearch.Common.Application.DTOs;

namespace FlightSearch.Common.MockGenerator;

public static class FlightMockDataGenerator
{
    public static List<FlightData> GenerateMockFlights(string origin, string destination, DateTime departureDate)
    {
        var faker = new Faker();

        var flights = new List<FlightData>();

        for (int i = 0; i < 5; i++) // 5 adet mock veri oluşturuyoruz
        {
            flights.Add(new FlightData
            {
                FlightNumber = faker.Random.AlphaNumeric(6),
                Departure = origin,
                Arrival = destination,
                Price = (double)faker.Finance.Amount(50, 500),
                Currency = "USD", // Assuming USD as the currency
                DepartureTime = departureDate.AddHours(faker.Random.Int(1, 12)).ToString("yyyy-MM-ddTHH:mm:ss"),
                ArrivalTime = departureDate.AddHours(faker.Random.Int(3, 15)).ToString("yyyy-MM-ddTHH:mm:ss"),
                Duration = $"{faker.Random.Int(4, 6)}h {faker.Random.Int(10, 60)}m", // Random duration between 4 to 6 hours
                ProviderName = faker.Company.CompanyName() // Random company name
            });
        }

        return flights;
    }
}