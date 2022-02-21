using System.Globalization;
using Fluxor;
using Fluxor.Blazor.Web.Middlewares.Routing;
using Microsoft.AspNetCore.WebUtilities;
using StatCan.Chms.Client.Services;

namespace StatCan.Chms.Client.Store.CultureSelection;

public class Effects
{
    private readonly CultureManager _cultureManager;
    private readonly ILogger<Effects> _logger;

    public Effects(CultureManager cultureManager, ILogger<Effects> logger)
    {
        _cultureManager = cultureManager;
        _logger = logger;
    }

    [EffectMethod]
    public Task ChangeCulture(CultureSelectionChangeCultureAction action, IDispatcher dispatcher)
    {
        _cultureManager.ChangeCulture(this, action.NewCulture);

        dispatcher.Dispatch(new CultureSelectionChangeCultureResultAction(_cultureManager.CurrentCulture));

        return Task.CompletedTask;
    }

    [EffectMethod]
    // We have to handle the GoAction because we can set the culture with the "culture" query parameter
    public Task Go(GoAction action, IDispatcher dispatcher)
    {
        _logger.LogDebug("Navigating to {Path}", action.NewUri);
        
        if (QueryHelpers.ParseQuery(new Uri(action.NewUri).Query).TryGetValue("culture", out var culture))
        {
            _logger.LogDebug("Changing culture to {Value}", culture);
            dispatcher.Dispatch(new CultureSelectionChangeCultureAction(new CultureInfo(culture)));
        }
        
        return Task.CompletedTask;
    }
}