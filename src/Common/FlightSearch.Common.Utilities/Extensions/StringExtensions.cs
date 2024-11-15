namespace FlightSearch.Common.Utilities.Extensions;

public static class StringExtensions
{
    public static string CombineUrls(this string baseUrl, string relativeUrl)
    {
        if (string.IsNullOrWhiteSpace(baseUrl))
            throw new ArgumentNullException(nameof(baseUrl));

        if (string.IsNullOrWhiteSpace(relativeUrl))
            throw new ArgumentNullException(nameof(relativeUrl));

        baseUrl = baseUrl.TrimEnd('/');
        relativeUrl = relativeUrl.TrimStart('/');

        return $"{baseUrl}/{relativeUrl}";
    }
}