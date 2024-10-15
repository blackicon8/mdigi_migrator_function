using System;

namespace AzureFunctionApp.Services.Mapper;

public static class MapperExtensions
{
    public static double? GetWeeklyBreakdownNetNet(double adRunUnits, double? adRunNetNet, double WeeklyBreakdownUnits)
    {
        if (adRunUnits > 0)
        {
            return adRunNetNet * WeeklyBreakdownUnits / adRunUnits;
        }

        return null;
    }

    public static string GetMediaType(this string advertisingCode)
    {
        string mediaType = null;

        if (advertisingCode == null) { return mediaType; }
        
        var advertisingCodeArray = advertisingCode.Split('/');

        if (advertisingCodeArray != null) 
        { 
            mediaType = advertisingCodeArray[0]; 
        }
        
        return mediaType;
    }

    public static string GetCurrency(this string pricingType)
    {
        if (string.IsNullOrWhiteSpace(pricingType))
            return string.Empty;

        if (!pricingType.Contains('/'))
            return pricingType;

        return pricingType.Split('/')[0];
    }

    public static string GetUnitType(this string pricingType)
    {
        string[] types = { "day", "week", "month", "view", "completed view", "interaction", "conversion", "lead", "sending" };

        if (string.IsNullOrWhiteSpace(pricingType))
            return string.Empty;

        if (!pricingType.Contains('/'))
            return pricingType;

        var result = pricingType.Split('/')[1];

        if (Array.Exists(types, el => el == result.ToLower()))
        {
            return result + "(s)";
        }

        return result;
    }

    public static string GetAdvertisingCode(this string advertisingCode)
    {
        if (string.IsNullOrWhiteSpace(advertisingCode))
            return string.Empty;

        if (!advertisingCode.Contains('/'))
            return advertisingCode;

        return advertisingCode.Split('/')[0];
    }
}
