using System;
using System.Linq;
using System.Web;

namespace AzureFunctionApp.Common.Extensions;
public static class UrlExtensions
{
    public static string AddLimit(this string url, int value)
    {
        return AddParameter(url, "limit", value.ToString());
    }

    public static string AddOffset(this string url, int value)
    {
        return AddParameter(url, "offset", value.ToString());
    }

    public static string AddSegment(this string url, string segment)
    {
        url = url.TrimEnd('/');
        segment = segment.TrimStart('/');
        return string.Format("{0}/{1}", url, segment);
    }

    public static string AddParameter(this string url, string key, string value)
    {
        string delimiter;
        if ((url == null) || !url.Contains("?"))
        {
            delimiter = "?";
        }
        else if (url.EndsWith("?") || url.EndsWith("&"))
        {
            delimiter = string.Empty;
        }
        else
        {
            delimiter = "&";
        }

        return url + delimiter + HttpUtility.UrlEncode(key)
            + "=" + HttpUtility.UrlEncode(value);
    }

    public static string AddParameter(this string url, string key, string[] values)
    {
        string delimiter;
        if ((url == null) || !url.Contains("?"))
        {
            delimiter = "?";
        }
        else if (url.EndsWith("?") || url.EndsWith("&"))
        {
            delimiter = string.Empty;
        }
        else
        {
            delimiter = "&";
        }

        var encodedValues = string.Join(",", values.Select(HttpUtility.UrlEncode));
        return url + delimiter + HttpUtility.UrlEncode(key) + "=" + encodedValues;
    }
}
