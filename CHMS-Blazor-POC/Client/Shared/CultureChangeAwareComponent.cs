using Microsoft.AspNetCore.Components;
using StatCan.Chms.Client.Services;

namespace StatCan.Chms.Client.Shared;

/// <summary>
/// A component that is aware when the cutlture was changed by the <see cref="Services.CultureManager"/>. By default, it re-renders the component on a culture
/// change.
/// </summary>
public class CultureChangeAwareComponent : ComponentBase, IDisposable
{
    [Inject]
    public CultureManager? CultureManager { private get; set; }

    [Inject]
    public ILogger<CultureChangeAwareComponent>? Logger { private get; set; }

    /// <inheritdoc/>
    protected override void OnInitialized()
    {
        if (CultureManager != null)
        {
            CultureManager.CultureChanged += OnCultureChanged;
        }

        base.OnInitialized();
    }

    /// <inheritdoc/>
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
        Logger?.LogDebug("OnCultureChanged in {Type}", this.GetType());

        // Should this be wrapped inside InvokeAsync in case the culture change was triggered from outside the renderer's synchronization context?
        // In theory, it shouldn't be necessary because the culture switch usually originate from an event on a component.
        //
        // See ASP.NET Core Blazor component rendering - To render a component outside the subtree that's rerendered by a particular event, https://docs.microsoft.com/en-us/aspnet/core/blazor/components/rendering?view=aspnetcore-6.0
        StateHasChanged();
    }
}
