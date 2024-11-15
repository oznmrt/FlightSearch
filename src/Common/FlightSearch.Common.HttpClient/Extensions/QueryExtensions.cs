using System.Web;

namespace FlightSearch.Common.GenericHttpClient.Extensions;

public static class QueryExtensions
{
    public static string ToQueryString<T>(this T request)
    {
        var properties = typeof(T).GetProperties();
        var queryString = HttpUtility.ParseQueryString(string.Empty);

        foreach (var prop in properties)
        {
            var value = prop.GetValue(request);
            if (value != null)
            {
                queryString[prop.Name] = value.ToString();
            }
        }

        return queryString.ToString()!;
    }
}