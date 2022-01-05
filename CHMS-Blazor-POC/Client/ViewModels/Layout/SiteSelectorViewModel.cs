using System.ComponentModel.DataAnnotations;
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

        Form = new SiteSelectorForm
        {
            Cycle = _appState.CurrentCycle?.Id ?? 0,
            Site = _appState.CurrentSite?.Id ?? 0
        };
    }

    public IEnumerable<Cycle> Cycles { get; private set; }
    
    public IEnumerable<Site> Sites { get; private set; }
    
    public SiteSelectorForm Form { get; }
    
    public async Task InitializeAsync()
    {
        Cycles = await _cycleService.GetCycles();
        
        if (Form.Site != null)
        {
            await FetchSitesAsync(false);
        }
    }

    public async Task FetchSitesAsync()
    {
        await FetchSitesAsync(true);
    }
    
    private async Task FetchSitesAsync(bool resetSelectedSite)
    {
        if (resetSelectedSite)
        {
            Form.Site = 0;
        }

        Sites = await _cycleService.GetSiteForCycle(Form.Cycle);
    }

    public async Task SaveAsync()
    {
        await Task.Run(() =>
        {
            Cycle? cycle = Cycles.FirstOrDefault(cycle => cycle.Id == Form.Cycle);
            Site? site = Sites.FirstOrDefault(site => site.Id == Form.Site);
            
            _appState.ChangeSite(this, cycle, site);
        });
    }

    public class SiteSelectorForm
    {
        public int Cycle { get; set; }
        
        public int Site { get; set; }
    }
}