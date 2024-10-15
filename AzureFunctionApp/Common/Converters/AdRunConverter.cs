using AzureFunctionApp.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzureFunctionApp.Common.Converters
{
    public class AdRunConverter : JsonConverter<AdRunDto>
    {
        public override AdRunDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var adRun = new AdRunDto();
            DateTime? startDate = null;
            DateTime? endDate = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return adRun;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    reader.Read();

                    switch (propertyName)
                    {
                        case "date":
                            if (reader.TokenType == JsonTokenType.StartArray)
                            {
                                reader.Read();

                                if (reader.TokenType == JsonTokenType.EndArray)
                                    break;

                                if (reader.TokenType == JsonTokenType.StartArray)
                                {
                                    reader.Read();
                                    startDate = reader.GetDateTime();
                                    reader.Read();
                                    endDate = reader.GetDateTime();
                                    reader.Read();
                                }
                                else
                                {
                                    startDate = reader.GetDateTime();
                                    endDate = startDate;
                                }
                            }
                            break;

                        case "id":
                            adRun.Id = reader.GetString();
                            break;
                        case "campaignId":
                            adRun.CampaignId = reader.GetString();
                            break;
                        case "customId":
                            adRun.CustomId = reader.GetString();
                            break;
                        case "placement":
                            adRun.Placement = reader.GetString();
                            break;
                        case "pricingType":
                            adRun.PricingType = reader.GetString();
                            break;
                        case "units":
                            adRun.Units = ParseIntFromString(ref reader);
                            break;
                        case "estimatedAV":
                            adRun.EstimatedAV = ParseDoubleFromString(ref reader);
                            break;
                        case "estimatedCT":
                            adRun.EstimatedCT = ParseIntFromString(ref reader);
                            break;
                        case "estimatedCTR":
                            adRun.EstimatedCTR = ParseDoubleFromString(ref reader);
                            break;
                        case "estimatedLead":
                            adRun.EstimatedLead = ParseDoubleFromString(ref reader);
                            break;
                        case "netNet":
                            adRun.NetNet = ParseDoubleFromString(ref reader);
                            break;
                        case "sumRatecard":
                            adRun.SumRatecard = ParseDoubleFromString(ref reader);
                            break;
                        case "advertisingCode":
                            adRun.AdvertisingCode = reader.GetString();
                            break;
                        case "weeklyBreakdown":
                            adRun.WeeklyBreakdown = JsonSerializer.Deserialize<List<WeeklyBreakdownDto>>(ref reader, options);
                            break;
                        case "salesHouse":
                            adRun.SalesHouse = JsonSerializer.Deserialize<SalesHouseDto>(ref reader, options);
                            break;
                        case "site":
                            adRun.Site = JsonSerializer.Deserialize<SiteDto>(ref reader, options);
                            break;
                        case "format":
                            adRun.Format = JsonSerializer.Deserialize<FormatDto>(ref reader, options);
                            break;
                        case "sizes":
                            adRun.Sizes = JsonSerializer.Deserialize<List<SizeDto>>(ref reader, options);
                            break;
                        default:
                            reader.Skip();
                            break;
                    }
                }

                adRun.StartDate = startDate;
                adRun.EndDate = endDate;
            }
            
            return adRun;
        }

        public override void Write(Utf8JsonWriter writer, AdRunDto value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        private int ParseIntFromString(ref Utf8JsonReader reader, int defaultValue = 0)
        {
            if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt32(out int parsedValue))
            {
                return parsedValue;
            }
            else
            {
                return defaultValue;
            }
        }

        private double ParseDoubleFromString(ref Utf8JsonReader reader, double defaultValue = 0)
        {
            if (reader.TokenType == JsonTokenType.Number && reader.TryGetDouble(out double parsedValue))
            {
                return parsedValue;
            }
            else
            {
                return defaultValue;
            }
        }
    }
}
