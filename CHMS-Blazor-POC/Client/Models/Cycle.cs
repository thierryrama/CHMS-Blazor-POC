namespace StatCan.Chms.Client.Models;

public class Cycle
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Site> Sites { get; set; }
}