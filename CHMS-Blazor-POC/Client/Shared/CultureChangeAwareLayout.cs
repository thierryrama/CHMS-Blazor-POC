using Microsoft.AspNetCore.Components;
using StatCan.Chms.Client.Services;

namespace StatCan.Chms.Client.Shared;

/// <summary>
/// A layout that is aware when the cutlture was changed by the <see cref="Services.CultureManager"/>. By default, it re-renders the component on a culture
/// change.
/// </summary>
/// <remarks>
/// With the way that the <see cref="CultureSelector"/> works by using a query parameter, this class is actually unnecessary. That is because the layout is automatically
/// re-rendered when the URI changes.
/// </remarks>
public class CultureChangeAwareLayout : LayoutComponentBase, IDisposable
{
    [Inject]
    private CultureManager? CultureManager { get; set; }

    protected override void OnInitialized()
    {
        if (CultureManager != null)
        {
            CultureManager.CultureChanged += OnCultureChanged;
        }

        base.OnInitialized();
    }

    public void Dispose()
    {
        if (CultureManager != null)
        {
            // To avoid memory leak, unregister the listener when the component is disposed.
            CultureManager.CultureChanged -= OnCultureChanged;
        }
    }

    /// <summary>
    /// Method invoked when the culture was changed by the <see cref="Services.CultureManager"/>. By default, it re-renders the component.
    /// </summary>
    /// <param name="sender">The originator of the cultur change</param>
    /// <param name="args">Details of the culture change</param>
    protected virtual void OnCultureChanged(object? sender, CultureChangedArgs args)
    {
        StateHasChanged();
    }
}
