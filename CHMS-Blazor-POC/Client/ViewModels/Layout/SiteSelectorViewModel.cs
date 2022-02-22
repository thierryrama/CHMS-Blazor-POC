using System.Collections.Immutable;
using StatCan.Chms.Client.Models;
using StatCan.Chms.Client.Services;

namespace StatCan.Chms.Client.ViewModels.Layout;

public class SiteSelectorViewModel
{
    private readonly CycleService _cycleService;
    private readonly AppState _appState;

    public SiteSelectorViewModel(CycleService cycleService, AppState appState)
    {
        _cycleService = cycleService;
        _appState = appState;

        if (appState.IsSiteSelected)
        {
            SelectedSite = new SelectableSite(appState.CurrentCycle!, appState.CurrentSite!);
        }
    }

    public IDictionary<Cycle, IEnumerable<SelectableSite>> SelectableSitesByCycle { get; private set; } =
        ImmutableDictionary<Cycle, IEnumerable<SelectableSite>>.Empty;

    public SelectableSite? SelectedSite { get; set; }

    public async Task InitializeAsync()
    {
        var cycles = await _cycleService.GetCycles();
        var getSitesTaskByCycle = new Dictionary<Cycle, Task<IEnumerable<Site>>>();
        foreach (var cycle in cycles)
        {
            getSitesTaskByCycle[cycle] = _cycleService.GetSitesForCycle(cycle.Id);
        }

        await Task.WhenAll(getSitesTaskByCycle.Values);

        var selectableSitesByCycle = new Dictionary<Cycle, IEnumerable<SelectableSite>>();
        foreach (var cycle in cycles)
        {
            selectableSitesByCycle[cycle] = getSitesTaskByCycle[cycle].Result
                .Select(site => new SelectableSite(cycle, site))
                .ToList();
        }

        SelectableSitesByCycle = selectableSitesByCycle;
    }

    public async Task SaveAsync(SelectableSite? selectedSite)
    {
        if (selectedSite == null || SelectableSitesByCycle.Values.Any(sites => sites.Contains(selectedSite)))
        {
            SelectedSite = selectedSite;
            _appState.ChangeSite(this, SelectedSite?.Cycle, SelectedSite?.Site);
        }

        await Task.CompletedTask;
    }

    public record SelectableSite(Cycle Cycle, Site Site);
}