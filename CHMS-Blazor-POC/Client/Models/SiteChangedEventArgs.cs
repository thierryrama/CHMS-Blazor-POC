namespace StatCan.Chms.Client.Models;

public class SiteChangedEventArgs : EventArgs
{
    public Cycle? OldCycle { get; }
    public Site? OldSite { get; }
    public Cycle? NewCycle { get; }
    public Site? NewSite { get; }

    public SiteChangedEventArgs(Cycle? oldCycle, Site? oldSite, Cycle? newCycle, Site? newSite)
    {
        OldCycle = oldCycle;
        OldSite = oldSite;
        NewCycle = newCycle;
        NewSite = newSite;
    }
}