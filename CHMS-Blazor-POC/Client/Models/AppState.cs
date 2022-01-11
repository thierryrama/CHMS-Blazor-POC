using System.Globalization;

namespace StatCan.Chms.Client.Models;

public class AppState
{
    public event EventHandler<SiteChangedEventArgs>? OnSiteChanged;
        
    public Cycle? CurrentCycle { get; private set; }
    
    public Site? CurrentSite { get; private set; }
    
    public SignedInUser? SignedInUser { get; set; }

    public void ChangeSite(object sender, Cycle? cycle, Site? site)
    {
        var args = new SiteChangedEventArgs(CurrentCycle, CurrentSite, cycle, site);

        CurrentCycle = cycle;
        CurrentSite = site;

        OnSiteChanged?.Invoke(sender, args);
    }

    public bool IsSiteSelected => CurrentSite != null;
}
