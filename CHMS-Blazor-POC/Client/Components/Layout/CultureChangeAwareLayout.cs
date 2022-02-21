using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using StatCan.Chms.Client.Store.CultureSelection;

namespace StatCan.Chms.Client.Components.Layout;

/// <summary>
/// A layout that re-renders on culture change.
/// </summary>
public class CultureChangeAwareLayout : FluxorLayout
{
    [Inject]
    // Don't remove this.
    // This is how Fluxor knows which state to track for this component. It does so by inspecting the states that
    // are injected ([Inject]) into the component.
    protected IState<CultureSelectionState> CultureSelectionState { get; set; } = null!;
}
