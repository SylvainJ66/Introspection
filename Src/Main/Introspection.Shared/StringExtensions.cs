using System.Globalization;
using System.Web;

namespace Introspection.Shared;

/// <summary>
/// String Extensions
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Append parameters in a query url
    /// Do not call multiple times
    /// </summary>
    /// <param name="url">The base url</param>
    /// <param name="queryParams">A collection of key value pair, corresponding to a parameter name and it's value. Null values are ignored</param>
    /// <returns>The formatted query url</returns>
    public static Uri AddQueryParameters(this Uri url, params ValueTuple<string, object>[] queryParams)
    {
        if (queryParams is null)
            return url;

        var queryString = HttpUtility.ParseQueryString(string.Empty);
        foreach(var p in queryParams)
        {
            if(p.Item1 != null && p.Item2 != null)
            {
                if(p.Item2 is DateTime dateParameter)
                    queryString[p.Item1] = dateParameter.ToUniversalTime().ToString(CultureInfo.InvariantCulture.DateTimeFormat.SortableDateTimePattern);
                else
                    queryString[p.Item1] = p.Item2.ToString();
            }
        }
        
        if (queryString.Count == 0) 
            return url;
        
        return new Uri($"{url}?{queryString}", UriKind.Relative);
    }

    /// <summary>
    /// Returns the current string as a relative Uri with the given query parameters
    /// </summary>
    /// <param name="url"></param>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    public static Uri AddQueryParameters(this string url, params ValueTuple<string, object>[] queryParams) => 
        AddQueryParameters(new Uri(url, UriKind.Relative), queryParams);
}