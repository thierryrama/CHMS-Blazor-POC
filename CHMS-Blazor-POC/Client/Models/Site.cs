namespace StatCan.Chms.Client.Models;

public class Site
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public TimeZoneInfo TimeZoneInfo { get; set; }
}