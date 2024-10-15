namespace AzureFunctionApp.Domain.DTOs;
public class JobDto
{
    public string Id { get; set; }
    public int JobId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string JobType { get; set; }
    public string ChannelId { get; set; }
    public string CampaignId { get; set; }
}
