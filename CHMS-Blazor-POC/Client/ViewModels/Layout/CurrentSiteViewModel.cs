using StatCan.Chms.Client.Models;

namespace StatCan.Chms.Client.ViewModels.Layout;

public class CurrentSiteViewModel : IDisposable
{
    private readonly AppState _appState;

    public CurrentSiteViewModel(AppState appState)
    {
        _appState = appState;
        _appState.OnSiteChanged += SiteChanged;
    }

    public event EventHandler<SiteChangedEventArgs> OnSiteChanged; 

    public string? CycleName
    {
        get => _appState?.CurrentCycle?.Name;
    }

    public string? SiteName
    {
        get => _appState?.CurrentSite?.Name;
    }

    public DateTime? Time
    {
        get => IsCurrentSiteAvailable() ? TimeZoneInfo.ConvertTime(DateTime.Now, _appState.CurrentSite!.TimeZoneInfo!) : null;
    }

    public bool IsCurrentSiteAvailable()
    {
        return CycleName != null && SiteName != null;
    }
    
    private void SiteChanged(object? sender, SiteChangedEventArgs e)
    {
        OnSiteChanged?.Invoke(sender, e);
    }

    public void Dispose()
    {
        _appState.OnSiteChanged -= SiteChanged;
    }
}