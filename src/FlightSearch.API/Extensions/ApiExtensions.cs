namespace FlightSearch.API.Extensions;

public static class ApiExtensions
{
    public static async Task<T> SafeApiCall<T>(this Task<T> apiCallTask)
    {
        try
        {
            return await apiCallTask;
        }
        catch (Exception ex)
        {
            // Log error if necessary
            return default!; // Or return an appropriate fallback value like an empty list
        }
    }
}