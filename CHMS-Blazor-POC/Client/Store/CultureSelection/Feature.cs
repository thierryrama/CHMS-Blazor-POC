using Fluxor;
using StatCan.Chms.Client.Services;

namespace StatCan.Chms.Client.Store.CultureSelection;

// We use an actual Feature instead of the [FeatureState] attribute on the state because we need to use a service.
public class Feature : Feature<CultureSelectionState>
{
    private readonly CultureManager _cultureManager;

    public Feature(CultureManager cultureManager)
    {
        _cultureManager = cultureManager;
    }

    public override string GetName()
    {
        return "CultureSelection";
    }

    protected override CultureSelectionState GetInitialState()
    {
        return new CultureSelectionState
        {
            SupportedCultures = _cultureManager.SupportedCultures,
            CurrentCulture = _cultureManager.CurrentCulture
        };
    }

    public override void RestoreState(object value)
    {
        // The .NET culture state isn't a Fluxor component and isn't bound to a Fluxor state. As such, we have to
        // manually restore it.
        if (value is CultureSelectionState stateToRestore)
        {
            _cultureManager.ChangeCulture(this, stateToRestore.CurrentCulture);
        }
        
        base.RestoreState(value);
    }
}