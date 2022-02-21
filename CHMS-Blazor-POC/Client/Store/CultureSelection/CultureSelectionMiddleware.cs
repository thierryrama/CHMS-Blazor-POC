using Fluxor;
using StatCan.Chms.Client.Services;

namespace StatCan.Chms.Client.Store.CultureSelection;

// This middleware is to support a change to the culture outside of the Fluxor flow.
public class CultureSelectionMiddleware : Middleware
{
    private readonly CultureManager _cultureManager;
    private IDispatcher? _dispatcher;

    public CultureSelectionMiddleware(CultureManager cultureManager)
    {
        _cultureManager = cultureManager;
    }

    public override Task InitializeAsync(IDispatcher dispatcher, IStore store)
    {
        _dispatcher = dispatcher;
        _cultureManager.CultureChanged += OnCultureChanged;
        
        return Task.CompletedTask;
    }
    
    private void OnCultureChanged(object? sender, CultureChangedArgs e)
    {
        // If the culture was changed outside the flow of the Culture Selection feature, sync the
        // state with the new value.
        //
        // We also check that we're not inside an internal middleware change such as during a state restoration.
        if (!IsInsideMiddlewareChange && (sender == null || sender.GetType() != typeof(Effects)))
        {
            _dispatcher!.Dispatch(new CultureSelectionChangeCultureResultAction(e.NewValue));
        }
    }
}